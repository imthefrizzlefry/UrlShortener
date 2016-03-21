using OpenQA.Selenium;

namespace UrlMiniUITests.TestFramework.PageObjects
{
    public static class IndexView
    {
        public static By LongUrlTextBox = By.Id("LongUrl");
        public static By ShortenUrlButton = By.Id("btnShortenUrl");
        public static By ShorterUrlSpan = By.Id("shorterURLResult");

        public static By ShortenedUrlAnchor = By.XPath("//*[@id='shorterURLResult']/a");

    }
}
