using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoogleVisionApi.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GoogleVisionApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ImageStoreContext _context;

        public HomeController(ImageStoreContext context)
        {
            _context = context;
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

        public IActionResult PlayGame()
        {



            return View();
        }

        public IActionResult NewPlayer()
        {

            return View();
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
