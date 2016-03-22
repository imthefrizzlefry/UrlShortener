using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;
using UrlMini.Models;

namespace UrlMini.Controllers
{
    public class HomeController : Controller
    {
        private string _message;

        public virtual string GetDecodedUrlAsString(string codecEndpoint)
        {
            // Create a WebRequest session to the endpoint
            WebRequest request = WebRequest.Create(codecEndpoint);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            //StreamReader reader = new StreamReader(dataStream);

            //var jsonResponseString = serializer.DeserializeObject(reader.ReadToEnd()); 
            DecodeResponse responseObject = new DecodeResponse();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(responseObject.GetType());
            responseObject = serializer.ReadObject(dataStream) as DecodeResponse;

            string redirectUrl = responseObject.Url;

            // Read the content and return string.
            return redirectUrl;
        }

        public ActionResult Index()
        {   
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            ViewBag.Message = _message;
            return View();
        }

        public ActionResult RedirectWithCode(string shortCode)
        {
            string codecEndpoint = string.Format("{0}api/codec/{1}", ConfigurationManager.AppSettings["ClientBaseAddress"].ToString(), shortCode);
            string redirectUrl = GetDecodedUrlAsString(codecEndpoint);

            if (redirectUrl == "NotFound")
            {
                _message = "There was a problem: " + redirectUrl;
                return RedirectToAction("NotFound", "Home");
            }

            return Redirect(redirectUrl);
         }

    }
}