using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlMini.Controllers;
using TestStack.FluentMVCTesting;
using UrlMini.Tests.TestFramework;
using System.Web.Routing;
using System.Web;
using Moq;
using System.Configuration;

namespace UrlMini.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            var result = controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
            

        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = controller.WithCallTo(x => x.About()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            var result = controller.WithCallTo(x => x.Contact()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void NotFound()
        {
            // Arrange
            var controller = new HomeController();

            var result = controller.WithCallTo(x => x.NotFound()).ShouldRenderDefaultView();
            
        }

        [TestMethod]
        public void RedirectWithValidCode()
        {
            // Arrange
            var mockController = new Mock<HomeController>();
            string shortCode = "1y5a";
            string expectedAPIEndpoint = string.Format("{0}api/codec/{1}", ConfigurationManager.AppSettings["ClientBaseAddress"].ToString(), shortCode);

            mockController.Setup(x => x.GetDecodedUrlAsString(expectedAPIEndpoint)).Returns("valid");

            //mockController.
            var result = mockController.Object.WithCallTo(x => x.RedirectWithCode(""));
            Assert.AreEqual(result.ActionName, "RedirectWithCode", "The expected Action was not returned.");
        }

        //[TestMethod]
        //public void RedirectWithinValidCode()
        //{
        //    // Arrange
        //    var mockController = new Mock<HomeController>();
        //    string shortCode = "1y5b";
        //    string expectedAPIEndpoint = string.Format("{0}api/codec/{1}", ConfigurationManager.AppSettings["ClientBaseAddress"].ToString(), shortCode);

        //    mockController.Setup(x => x.GetDecodedUrlAsString(expectedAPIEndpoint)).Returns("NotFound");

        //    //mockController.
        //    var result = mockController.Object.WithCallTo(x => x.RedirectWithCode("")).ShouldRedirectToRoute("NotFound");
        //    //Assert.AreEqual(result.ActionName, "RedirectWithCode", "The expected Action was not returned.");
        //}



    }
}
