using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlMini.Controllers;
using UrlMini.Tests.TestFramework;

namespace UrlMini.Tests.Controllers
{
    [TestClass]
    public class CodecControllerTest
    {
       
        [TestMethod]
        public void EncodeValidUrl()
        {
            string inputTimeStamp = DateTime.Now.ToString("yyyyMMdd");
            string inputUrl = @"https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=test+Query+" + inputTimeStamp;
            int preRecordCount = DataAccess.GetRecordCount();

            UrlMini.Models.EncodeRequest inputRequest = new UrlMini.Models.EncodeRequest();
            inputRequest.Url = inputUrl;

            CodecController controller = new CodecController();

            UrlMini.Models.EncodeResponse testResponse = controller.Post(inputRequest);

            int postRecordCount = DataAccess.GetRecordCount();

            
            Assert.IsTrue((preRecordCount < postRecordCount), "The number or records in the database did not increase!");

            DataAccess.RemoveRecord(DataAccess.GetMostRecentRecordId());

            Assert.IsNotNull(testResponse, "A Null Response was returned by the codec post controller");

        }

        [TestMethod]
        public void DecodeValidUrl()
        {
            CodecController controller = new CodecController();

            UrlMini.Models.DecodeResponse testResponse = controller.Get("1y5a");

            Assert.AreEqual("https://home.stevenfarnell.net", testResponse.Url, "The requested Url returned by the controller does not match the expacted value");

        }
    }
}
