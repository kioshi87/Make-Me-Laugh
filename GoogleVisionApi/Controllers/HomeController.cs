using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleVisionApi.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GoogleVisionApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageStoreContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly ISession _session;

        public HomeController(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, ImageStoreContext context )
        {
            _environment = hostingEnvironment;
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
            var _player = new PlayerModel(); 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FaceResults()
        {

            var imageStoreList = _context.ImageStore.OrderByDescending(image => image.ImageStoreId).ToList();

            return View(imageStoreList);

        }

        public IActionResult GameResults()
        {
            var player = _context.PlayerModel.First(x => x.PlayerId == _session.GetInt32("playerId"));           
            var playerImages = GetPlayerImages();
            var playerLaughingImages = new List<ImageStore>();

            foreach (var image in playerImages)
            {
                if (image.JoyLikelihood != null && (image.JoyLikelihood.ToUpper() == "VERYLIKELY" 
                    || image.JoyLikelihood.ToUpper() == "LIKELY" 
                    || image.JoyLikelihood.ToUpper() == "POSSIBLE"))
                {
                    player.Score -= 1;
                    playerLaughingImages.Add(image);
                }

            }
            _context.PlayerModel.Update(player);
            _context.SaveChanges();
            _session.SetInt32("playerScore", player.Score);

            return View(playerLaughingImages);
        }

        public List<ImageStore> GetPlayerImages()
        {
            var imageStoreList = _context.ImageStore.OrderByDescending(image => image.ImageStoreId)
                .Where(image => image.PlayerId == _session.GetInt32("playerId")).ToList();

            return imageStoreList;
        }

        public IActionResult PlayGame(PlayerModel player)
        {

            return View();
        }

        public IActionResult NewPlayer()
        {
            return View();
        }


        // Sends data from the form to the database via HttpPost attribute
        // Validation is done server side through the ModelState.IsValid below
        [HttpPost]
        public IActionResult NewPlayer(PlayerModel player)
        {
           
            if (ModelState.IsValid && player.PlayerName != null)
            {

                _context.PlayerModel.Add(player);
                _context.SaveChanges();
                _session.SetInt32("playerId", player.PlayerId);
                _session.SetString("playerName", player.PlayerName);
                _session.SetInt32("playerScore", player.Score);
                return RedirectToAction("PlayGame", player);
            }

            return View();
            
        }

        [HttpPost]
        public IActionResult Capture(string name)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting Filename  
                        var fileName = file.FileName;
                        // Unique filename "Guid"  
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        // Getting Extension  
                        var fileExtension = Path.GetExtension(fileName);
                        // Concating filename + fileExtension (unique filename)  
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        //  Generating Path to store photo   
                        var filepath = Path.Combine(_environment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";

                        if (!string.IsNullOrEmpty(filepath))
                        {
                            // Storing Image in Folder  
                            StoreInFolder(file, filepath);

                        }

                        var imageBytes = System.IO.File.ReadAllBytes(filepath);


                        if (imageBytes != null)
                        {
                            // Storing Image in Folder  
                            // look at sending image through Google Vision here -- maybe
                            StoreInDatabase(imageBytes);
                        }

                    }
                }
                return Json(Url.Action("FaceResults", "Home"));
            }
            else
            {
                return Json(false);
            }
        }

        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private void StoreInDatabase(byte[] imageBytes)
        {
            try
            {
                if (imageBytes != null)
                {
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

                    var faceAnnotations = GoogleCloudPlatformApi.GoogleVisionApiClient.GetFaceAnnotations(imageBytes);

                    ImageStore imageStore = new ImageStore()
                    {
                        CreateDate = DateTime.Now,
                        ImageBase64String = imageUrl,
                        ImageStoreId = 0,
                        AngerLikelihood = faceAnnotations[0],
                        JoyLikelihood = faceAnnotations[1],
                        SorrowLikelihood = faceAnnotations[2],
                        SurpriseLikelihood = faceAnnotations[3],
                        PlayerId = (int)_session.GetInt32("playerId") 
                    };

                    _context.ImageStore.Add(imageStore);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult LowestScores()
        {
            var lowestScoresPlayerList = new List<PlayerModel>();
            var worstPlayers = _context.PlayerModel.OrderBy(x => x.Score).Take(10).ToList();

            foreach (var player in worstPlayers)
            {
                var lowScorePlayer = new PlayerModel() { Score = player.Score };
                lowScorePlayer.ImageList = new List<ImageStore>();
                lowScorePlayer.PlayerName = player.PlayerName;
                
                var lowScorePlayersPics = _context.ImageStore.Where(image => image.PlayerId == player.PlayerId 
                && (image.JoyLikelihood != null && (image.JoyLikelihood.ToUpper() == "VERYLIKELY"
                    || image.JoyLikelihood.ToUpper() == "LIKELY"
                    || image.JoyLikelihood.ToUpper() == "POSSIBLE")));

                foreach (var pic in lowScorePlayersPics)
                {
                    lowScorePlayer.ImageList.Add(pic);
                }

                lowestScoresPlayerList.Add(lowScorePlayer);
            }
            
            return View(lowestScoresPlayerList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
