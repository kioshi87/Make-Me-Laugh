using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoogleVisionApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoogleVisionApi.Controllers
{
    public class CameraController : Controller
    {
        private readonly ImageStoreContext _context;
        private readonly IHostingEnvironment _environment;
        public CameraController(IHostingEnvironment hostingEnvironment, ImageStoreContext context)
        {
            _environment = hostingEnvironment;
            _context = context;
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

                        //return RedirectToAction("FaceResults", "Home");

                        if (imageBytes != null)
                        {
                            // Storing Image in Folder  
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
        /// <summary>  
        /// Saving captured image into Folder.  
        /// </summary>  
        /// <param name="file"></param>  
        /// <param name="fileName"></param>  

        public IActionResult Index()
        {
            var faceList = new List<FaceDetails>();
            string path = "wwwroot/CameraPhotos";
            var filePaths = Directory.GetFiles(path);

            foreach (var imageName in filePaths)
            {
                var faceAnnotations = GoogleCloudPlatformApi.GoogleVisionApiClient.GetFaceAnnotations(imageName);
                faceList.Add(new FaceDetails
                {
                    ImagePath = imageName.Remove(0, 8),
                    Anger = faceAnnotations[0],
                    Joy = faceAnnotations[1],
                    Sorrow = faceAnnotations[2],
                    Surprise = faceAnnotations[3]
                });
            }

            return View(faceList);
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

                    ImageStore imageStore = new ImageStore()
                    {
                        CreateDate = DateTime.Now,
                        ImageBase64String = imageUrl,
                        ImageStoreId = 0
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
    }
}
    
