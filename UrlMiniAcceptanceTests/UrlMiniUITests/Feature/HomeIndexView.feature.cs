﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.0.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UrlMiniUITests.Feature
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class HomeIndexViewFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "HomeIndexView.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "HomeIndexView", "\tIn order to obtain and use short codes\r\n\tAs an end user\r\n\tI want to be able to s" +
                    "ubmit Urls and use the short code", ProgrammingLanguage.CSharp, new string[] {
                        "UIAcceptanceTests"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "HomeIndexView")))
            {
                UrlMiniUITests.Feature.HomeIndexViewFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void TheUserObtainsAShortCodeWhenTheySubmitAValidURL(string url, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "HappyPath"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The user obtains a short code when they submit a valid URL", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("the user has a URL \'{0}\' that they want to have shortened", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("the user navigates to the home page and enters a URL to shorten", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.When("the user clicks Shorten Url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("a short-code is generated in the output area", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.Then("Clicking the short-code link takes the user to the desired page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user obtains a short code when they submit a valid URL: https://home.stevenfa" +
            "rnell.net/<TIMESTAMP>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "https://home.stevenfarnell.net/<TIMESTAMP>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "https://home.stevenfarnell.net/<TIMESTAMP>")]
        public virtual void TheUserObtainsAShortCodeWhenTheySubmitAValidURL_HttpsHome_Stevenfarnell_NetTIMESTAMP()
        {
            this.TheUserObtainsAShortCodeWhenTheySubmitAValidURL("https://home.stevenfarnell.net/<TIMESTAMP>", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user obtains a short code when they submit a valid URL: https://www.google.co" +
            "m/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-8#q=test%20search%20" +
            "terms%20<TIMESTAMP>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-" +
            "8#q=test%20search%20terms%20<TIMESTAMP>")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-" +
            "8#q=test%20search%20terms%20<TIMESTAMP>")]
        public virtual void TheUserObtainsAShortCodeWhenTheySubmitAValidURL_HttpsWww_Google_ComWebhpSourceidChrome_InstantIon1Espv2Es_Th1IeUTF_8QTest20Search20Terms20TIMESTAMP()
        {
            this.TheUserObtainsAShortCodeWhenTheySubmitAValidURL("https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-" +
                    "8#q=test%20search%20terms%20<TIMESTAMP>", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is redirected to the desired page when they load the shortlink")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HappyPath")]
        public virtual void TheUserIsRedirectedToTheDesiredPageWhenTheyLoadTheShortlink()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The user is redirected to the desired page when they load the shortlink", new string[] {
                        "HappyPath"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("the user has a short-code \'1y5a\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.When("the user attempts to navigate to the short-code Url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("the user is redirected to the \'https://home.stevenfarnell.net/\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void TheUserIsNotAbleToSubmitAnInvalidURL(string url, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Negative"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The user is not able to submit an invalid URL", @__tags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given(string.Format("the user has a invalid URL \'{0}\' that they want to have shortened", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.When("the user navigates to the home page and enters a URL to shorten", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("the Shorten URL button is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is not able to submit an invalid URL: invalid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Negative")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "invalid")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "invalid")]
        public virtual void TheUserIsNotAbleToSubmitAnInvalidURL_Invalid()
        {
            this.TheUserIsNotAbleToSubmitAnInvalidURL("invalid", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is not able to submit an invalid URL: https:incomplete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Negative")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "https:incomplete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "https:incomplete")]
        public virtual void TheUserIsNotAbleToSubmitAnInvalidURL_HttpsIncomplete()
        {
            this.TheUserIsNotAbleToSubmitAnInvalidURL("https:incomplete", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is not able to submit an invalid URL: http://\"noquotes")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Negative")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "http://\"noquotes")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "http://\"noquotes")]
        public virtual void TheUserIsNotAbleToSubmitAnInvalidURL_HttpNoquotes()
        {
            this.TheUserIsNotAbleToSubmitAnInvalidURL("http://\"noquotes", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is not able to submit an invalid URL: https:// no spaces")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Negative")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "https:// no spaces")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "https:// no spaces")]
        public virtual void TheUserIsNotAbleToSubmitAnInvalidURL_HttpsNoSpaces()
        {
            this.TheUserIsNotAbleToSubmitAnInvalidURL("https:// no spaces", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is not able to submit an invalid URL: ftp://unsupportedUrl")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Negative")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ftp://unsupportedUrl")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:url", "ftp://unsupportedUrl")]
        public virtual void TheUserIsNotAbleToSubmitAnInvalidURL_FtpUnsupportedUrl()
        {
            this.TheUserIsNotAbleToSubmitAnInvalidURL("ftp://unsupportedUrl", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("The user is given a graceful error when they attempt to load an invalid shortlink" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "HomeIndexView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("UIAcceptanceTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Negative")]
        public virtual void TheUserIsGivenAGracefulErrorWhenTheyAttemptToLoadAnInvalidShortlink()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The user is given a graceful error when they attempt to load an invalid shortlink" +
                    "", new string[] {
                        "Negative"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("the user has a short-code \'1y5b\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When("the user attempts to navigate to the short-code Url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("the user is redirected to the error page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion