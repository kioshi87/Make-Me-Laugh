using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.GoogleCloudPlatformApi
{
    public class GoogleVisionApiClient
    {
        // This class finds the images saved in the folder path
        public static string[] GetFaceAnnotations(string imagePath)
        {
            var faceAnnotationsList = new string[4];
            // Similar to HttpClient, Instantiates a client
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

        // This class gets the response from Google for a single image file
        // The data coming from GoogleVision is JSON
        public static string[] GetFaceAnnotations(byte[] imageBytes)
        {
            var faceAnnotationsList = new string[4];
            // Instantiates a client
            var client = ImageAnnotatorClient.Create();
            // Load the image file into memory
            var image = Image.FromBytes(imageBytes);
            // Performs label detection on the image file
            var response = client.DetectFaces(image);

            // Receives response and stores in the database 
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
