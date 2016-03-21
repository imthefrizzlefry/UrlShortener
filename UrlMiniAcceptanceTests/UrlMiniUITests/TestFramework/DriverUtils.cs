using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UrlMiniUITests.TestFramework
{
    public static class DriverUtils
    {
        #region Private Methods
        internal static void WaitUntilElementVisible(IWebDriver driver, By element, int duration = 50)
        {
            WebDriverWait webDelay = new WebDriverWait(driver, TimeSpan.FromSeconds(duration));
            webDelay.Until(ExpectedConditions.ElementIsVisible(element));
        }

        internal static void WaitUntilElementVisible(IWebElement element, int duration = 80)
        {
            var w = new DefaultWait<IWebElement>(element) { Timeout = TimeSpan.FromSeconds(duration) };
            w.IgnoreExceptionTypes(typeof(NoSuchElementException));

            w.Until(ctx =>
            {
                var elem = element;
                return elem.Displayed ? elem : null;
            });
        }

        #endregion

        internal static IWebDriver createWebdriverSession(string browserName)
        {
            IWebDriver driver;

            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    
                    driver = new ChromeDriver(@"C:\Program Files (x86)\chromedriver_win32");
                    break;
                case "IE":
                    driver = new InternetExplorerDriver(@"C:\Program Files (x86)\IEDriverServer_Win32");
                    break;
                case "auto_UnitBrowser":
                    driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());
                    break;
                default:
                    /* Not implemented because I don't have an active subscription to a remote webdriver service, 
                       but useful for remotely executing webdriver tests on something like browserstack or saucelabs                        
                    driver = this.InitializeRemoteWebDriverSession(browserName);
                    */

                    // default to Firefox because it has the least configuration
                    driver = new FirefoxDriver();
                    break;
            }
            return driver;
        }


        internal static void TypeIntoTextBox(IWebDriver driver, By element, string textToType, int waitDuration = 10)
        {
            WaitUntilElementVisible(driver, element, waitDuration);
            driver.FindElement(element).Clear();
            driver.FindElement(element).SendKeys(textToType);
        }

        internal static void ClickOnElement(IWebDriver driver, By element, int waitDuration = 10)
        {
            WaitUntilElementVisible(driver, element, waitDuration);
            driver.FindElement(element).Click();
        }

        internal static bool IsElementDisabled(IWebDriver driver, By element)
        {
            IWebElement webElement = driver.FindElement(element);
            string disabledStatus = webElement.GetAttribute("disabled");
            return (disabledStatus == "true");
        }

        internal static void NavigateToUrl(IWebDriver driver, string destination, int waitDuration = 50)
        {
            driver.Navigate().GoToUrl(destination);

            Thread.Sleep(waitDuration);
        }

        internal static string GetCurrentUrl(IWebDriver driver, int waitDuration = 0)
        {            
            Thread.Sleep(waitDuration);

            return driver.Url.ToString();
        }

        internal static void SwitchToNewWindow(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        internal static string GetElementText(IWebDriver driver, By element, int waitDuration = 0)
        {
            Thread.Sleep(waitDuration);

            return driver.FindElement(element).Text;
        }
    }
}
