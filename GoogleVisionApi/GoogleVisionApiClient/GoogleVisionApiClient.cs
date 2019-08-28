using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.GoogleVisionApiClient
{
    public class GoogleVisionApiClient
    {
        public static string[] GetFaceAnnotations(string imagePath)
        {
            var faceAnnotationsList = new string[4];
            // Instantiates a client
            var client = ImageAnnotatorClient.Create();
            // Load the image file into memory
            var image = Image.FromFile(imagePath);
            // Performs label detection on the image file
            var response = client.DetectFaces(image);

            foreach (var annotation in response)
            {
                //if (annotation. != null)
                faceAnnotationsList[0] = annotation.AngerLikelihood.ToString();
                faceAnnotationsList[1] = annotation.JoyLikelihood.ToString();
                faceAnnotationsList[2] = annotation.SorrowLikelihood.ToString();
                faceAnnotationsList[3] = annotation.SurpriseLikelihood.ToString();
            }

            return faceAnnotationsList;
        }
    }
}
