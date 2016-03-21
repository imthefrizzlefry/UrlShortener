using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using UrlMiniUITests.TestFramework;
using System.Configuration;
using CommonFramework;
using UrlMiniUITests.TestFramework.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Linq;

namespace UrlMiniUITests.Steps
{
    [Binding]
    public class HomeIndexViewSteps
    {

        [BeforeScenario]
        public void ScenarioSetup()
        {
            //read desired browser from app.config
            string desiredBrowser = ConfigurationManager.AppSettings["desiredWebBrowser"].ToString();

            //identify the base URl for our tests
            string baseAddress = ConfigurationManager.AppSettings["ClientBaseAddress"].ToString();

            //create new instance of selenium webdriver
            IWebDriver driver = DriverUtils.createWebdriverSession(desiredBrowser);

            //open webdriver session

            //add values to scenario context
            ScenarioContext.Current.Add("DesiredBrowser", desiredBrowser);
            ScenarioContext.Current.Add("BaseAddress", baseAddress);
            ScenarioContext.Current.Add("DriverSession", driver);
        }

        [AfterScenario]
        public void ScenarioCleanup()
        {
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];

            //close webdriver session
            driver.Close();
            driver.Quit();
        }

        #region Given Statements

        [Given(@"the user has a URL '(.*)' that they want to have shortened")]
        [Given(@"the user has a invalid URL '(.*)' that they want to have shortened")]
        public void GivenTheUserHasAURLThatTheyWantToHaveShortened(string urlToShorten)
        {
            urlToShorten = CommonMethods.ProcessUrlPassedByFeature(urlToShorten);

            ScenarioContext.Current.Add("UrlToBeShortened", urlToShorten);
        }     
        
        [Given(@"the user has a short-code '(.*)'")]
        public void GivenTheUserHasAShort_Code(string shortCode)
        {
            ScenarioContext.Current.Add("ShortCode", shortCode);
        }

        #endregion

        #region When Statements

        [When(@"the user navigates to the home page and enters a URL to shorten")]
        public void WhenTheUserNavigatesToTheHomePageAndEntersAShort_Code()
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];
            string baseAddress = ScenarioContext.Current["BaseAddress"].ToString();
            string urlToBeShortened = ScenarioContext.Current["UrlToBeShortened"].ToString();

            //navigate to home page
            DriverUtils.NavigateToUrl(driver, baseAddress);

            // type the URL into the text box
            DriverUtils.TypeIntoTextBox(driver, IndexView.LongUrlTextBox, urlToBeShortened);
        }
        
        [When(@"the user clicks Shorten Url")]
        public void WhenTheUserClicksShortenUrl()
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];

            DriverUtils.ClickOnElement(driver, IndexView.ShortenUrlButton);

            Thread.Sleep(50);            
        }
        
        [When(@"the user attempts to navigate to the short-code Url")]
        public void WhenTheUserAttemptsToNavigateToTheShort_CodeUrl()
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];
            string baseAddress = ScenarioContext.Current["BaseAddress"].ToString();
            string shortCode = ScenarioContext.Current["ShortCode"].ToString();
            string shortUrl = string.Format("{0}/{1}", baseAddress, shortCode);

            DriverUtils.NavigateToUrl(driver, shortUrl, 100);    
        }

        #endregion

        #region Then Statements

        [Then(@"a short-code is generated in the output area")]
        public void ThenAShort_CodeIsGeneratedInTheOutputArea()
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];

            try
            {
                DriverUtils.WaitUntilElementVisible(driver, IndexView.ShortenedUrlAnchor);
                IWebElement shortenedUrlAnchorElement = driver.FindElement(IndexView.ShortenedUrlAnchor);
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail("The link to the Shortened URL was not found: " + e.Message);
            }
        }

        [Then(@"Clicking the short-code link takes the user to the desired page")]
        public void ThenClickingTheShort_CodeLinkTakesTheUserToTheDesiredPage()
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];
            string desiredUrl = ScenarioContext.Current["UrlToBeShortened"].ToString();

            try
            {
                DriverUtils.ClickOnElement(driver, IndexView.ShortenedUrlAnchor);
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail("The link to the Shortened URL was not found: " + e.Message);
            }

            //switch to new window.
            DriverUtils.SwitchToNewWindow(driver);

            Thread.Sleep(50);

            string actualUrl = DriverUtils.GetCurrentUrl(driver);

            Assert.AreEqual(desiredUrl, actualUrl, "The Short Link did now lead the user to the desired URL");          

            
        }

        [Then(@"the user is redirected to the '(.*)' page")]
        public void ThenTheUserIsRedirectedToTheDesiredPage(string desiredUrl)
        {

            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];

            string actualUrl = DriverUtils.GetCurrentUrl(driver);

            Assert.AreEqual(desiredUrl, actualUrl, "The Short Link did now lead the user to the desired URL");
        }

        [Then(@"the Shorten URL button is disabled")]
        public void ThenTheShortenURLButtonIsDisabled()
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];
            bool isButtonDisabled;

            isButtonDisabled = DriverUtils.IsElementDisabled(driver, IndexView.ShortenUrlButton);

            Assert.IsTrue(isButtonDisabled, "The Shorten Url Button should be disabled, but is not.");
        }

        [Then(@"the user is redirected to the '(.*)' error page")]
        public void ThenTheUserIsRedirectedToTheErrorPage(string expectedTitle)
        {
            //retrieve values from Scenario Context
            IWebDriver driver = (IWebDriver)ScenarioContext.Current["DriverSession"];
            string actualUrl = DriverUtils.GetCurrentUrl(driver, 20);            
            string expectedUrl = string.Format("{0}{1}", ScenarioContext.Current["BaseAddress"].ToString(), "Home/NotFound");

            string actualMessage = DriverUtils.GetElementText(driver, NotFoundView.NotFoundMessage);
            string expectedMessage = "Code Not Found!";
            string actualTitle = DriverUtils.GetCurrentPageTitle(driver);

            Assert.IsTrue(actualTitle.Contains(expectedTitle), "The Page title does not include " + expectedTitle);

            if (expectedTitle == "Not Found")
            {
                Assert.AreEqual(expectedUrl, actualUrl, "The Not Found Url is not correct.");
                Assert.AreEqual(expectedMessage, actualMessage, "The Not Found Message was not found.");
            }
        }

        #endregion

    }
}
