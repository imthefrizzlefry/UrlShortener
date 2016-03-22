using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlMini.Controllers;
using Moq;
using System.Web;

namespace UrlMini.Tests.TestFramework
{
    //public class MockHomeController : HomeController
    //{
    //    //public override 
    //    //GetDecodedUrlAsString.Setup(
    //}

    //public static class MvcMoqHelpers
    //{
    //    public static HttpContextBase FakeHttpContext(string url)
    //    {
    //        HttpContextBase context = FakeHttpContext();
    //        context.Request.SetupRequestUrl(url);
    //        return context;
    //    }

    //    public static HttpContextBase FakeHttpContext()
    //    {
    //        var context = new Mock<HttpContextBase>();
    //        var request = new Mock<HttpRequestBase>();
    //        var response = new Mock<HttpResponseBase>();
    //        var session = new Mock<HttpSessionStateBase>();
    //        var server = new Mock<HttpServerUtilityBase>();


    //        request.Setup(r => r.Url.Scheme).Returns("http");
    //        request.Setup(r => r.Url.Authority).Returns("test.com");

    //        response.Setup(s => s.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

    //        context.Setup(ctx => ctx.Request).Returns(request.Object);
    //        context.Setup(ctx => ctx.Response).Returns(response.Object);
    //        context.Setup(ctx => ctx.Session).Returns(session.Object);
    //        context.Setup(ctx => ctx.Server).Returns(server.Object);

    //        return context.Object;
    //    }
    //}
}
