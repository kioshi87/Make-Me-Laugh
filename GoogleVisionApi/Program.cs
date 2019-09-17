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
        //    var jokeText = "Where do you find a cow with no legs? Right where you left it.";
        //    GoogleVisionApi.GoogleCloudPlatformApi.GoogleTextToSpeechClient.GetSpeechFromText(jokeText);

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
