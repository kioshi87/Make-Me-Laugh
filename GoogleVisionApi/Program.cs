using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GoogleVisionApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// Instantiates a client
            //var client = ImageAnnotatorClient.Create();
            //// Load the image file into memory
            //var image = Image.FromFile("images/face.png");
            //// Performs label detection on the image file
            //var response = client.DetectFaces(image);
            //foreach (var annotation in response)
            //{
            //    //if (annotation. != null)
            //    Console.WriteLine(annotation.AngerLikelihood);
            //    Console.WriteLine(annotation.JoyLikelihood);
            //    Console.WriteLine(annotation.SorrowLikelihood);
            //    Console.WriteLine(annotation.SurpriseLikelihood);

            //}

            CreateWebHostBuilder(args).Build().Run();


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
