using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleVisionApi.Models;
using System.IO;

namespace GoogleVisionApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var faceList = new List<FaceDetails>();
            string path = "wwwroot/CameraPhotos/";
            var filePaths = Directory.GetFiles(path);

            foreach (var imageName in filePaths)
            {
                var faceAnnotations = GoogleVisionApiClient.GoogleVisionApiClient.GetFaceAnnotations(imageName);
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

        //public IActionResult FaceResults()
        //{
        //    var faceList = new List<FaceDetails>();
        //    string path = "wwwroot/CameraPhotos/";
        //    var filePaths = Directory.GetFiles(path);

        //    foreach (var imageName in filePaths)
        //    {
        //        var faceAnnotations = GoogleVisionApiClient.GoogleVisionApiClient.GetFaceAnnotations(imageName);
        //        faceList.Add(new FaceDetails
        //        {
        //            ImagePath = imageName.Remove(0, 8),
        //            Anger = faceAnnotations[0],
        //            Joy = faceAnnotations[1],
        //            Sorrow = faceAnnotations[2],
        //            Surprise = faceAnnotations[3]
        //        });
        //    }

        //    return View(faceList);

        //}

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
