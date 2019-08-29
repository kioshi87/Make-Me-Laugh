﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebCam.Controllers
{
    public class CameraController : Controller
    {
        //private readonly DatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public CameraController(IHostingEnvironment hostingEnvironment /*DatabaseContext context*/)
        {
            _environment = hostingEnvironment;
           // _context = context;
        }
    
        public IActionResult Capture()
        {
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

                        // var imageBytes = System.IO.File.ReadAllBytes(filepath);
                        //if (imageBytes != null)
                        //{
                        //    // Storing Image in Folder  
                        //    StoreInDatabase(imageBytes);
                        //}

                    }
                }
                return Json(true);
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
        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }
    }
}