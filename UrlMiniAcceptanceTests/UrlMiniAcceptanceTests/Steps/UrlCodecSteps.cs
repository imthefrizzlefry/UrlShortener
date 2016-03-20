using System;
using TechTalk.SpecFlow;
using UrlMiniAcceptanceTests.CodecApiTests.TestFramework.Models;
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace UrlMiniAcceptanceTests.CodecApiTests.Steps
{
    [Binding]
    public class UrlCodecSteps
    {
        #region Private Methods        

        private string ProcessUrlPassedByFeature(string requestedUrl)
        {      
            //insert a timestamp to make test entry unique      
            if(requestedUrl.Contains("<TIMESTAMP>"))
            {
                string currentTime = DateTime.Now.ToString("yyyyMMddHHMM");
                requestedUrl = requestedUrl.Replace("<TIMESTAMP>", currentTime);
            }

            return requestedUrl;
        }

        private static string GetDecoderResponseAsString(string codecEndpoint)
        {
            //determine full Uri Endpoint
            string fullUriEndpoint = ConfigurationManager.AppSettings["ClientBaseAddress"].ToString() + codecEndpoint;
            // Create a WebRequest session to the endpoint
            WebRequest request = WebRequest.Create(fullUriEndpoint);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);

            // Read the content and return string.
            return reader.ReadToEnd();
        }

        private static HttpClient GetNewHttpClient()
        {
            string clientBaseAddress = ConfigurationManager.AppSettings["ClientBaseAddress"];

            //create HTTP session pointing to the base address with appropriate HTTP headers:
            //  Content-Type: application/json
            HttpClient codecClient = new HttpClient { Timeout = TimeSpan.FromMilliseconds(10000) };
            codecClient.BaseAddress = new Uri(clientBaseAddress);
            //codecPostClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            return codecClient;
        }

        #endregion

        #region Scenario Setup and Cleanup
        [BeforeScenario]
        public void ScenarioSetup()
        {
            //retrieve number of records currently in database
            int recordCount = DataAccess.GetRecordCount();

            //store number of records into ScenarioContext
            ScenarioContext.Current.Add("PreRecordCount", recordCount);
            Console.WriteLine("Pre Record Count was added to Scenario Context: " + recordCount);
        }

        [AfterScenario]
        public void ScenarioCleanup()
        {
            //retrieve number of records currently in database
            int postRecordCount = DataAccess.GetRecordCount();
            int preRecordCount = (int)ScenarioContext.Current["PreRecordCount"];
            

            if (ScenarioContext.Current.ContainsKey("EntriesAdded") && postRecordCount > preRecordCount)
            {
                int entriesAdded = (int)ScenarioContext.Current["EntriesAdded"];

                Assert.AreEqual(entriesAdded, (postRecordCount - preRecordCount), "FAIL: The incorrect number or records were added!");

                for (int counter=1; counter <= (int)ScenarioContext.Current["EntriesAdded"]; counter++)
                {
                    //Get most recent ID from Database
                    int curId = DataAccess.GetMostRecentRecordId();

                    //Verify the most recent item is not the default item deployed with the database
                    if (curId > 1)
                    {
                        DataAccess.RemoveRecord(curId);
                    }
                    else
                    {
                        Assert.Fail("An Item that should have been added to the database was not actually added!");
                    }
                }
            }
            else
            {
                Assert.AreEqual(preRecordCount, postRecordCount, ScenarioContext.Current.ScenarioInfo.Title
                                                                 + "FAIL: The record count should not have changed during the test, but changed by: "
                                                                 + (postRecordCount - preRecordCount).ToString());
            }
        }

        #endregion

        #region Given Statements

        [Given(@"A user wants to encode the URL: '(.*)'")]
        public void GivenAUserWantsToEncodeA(string requestedUrl)
        {
            // Process the Url Passed by the user:
            requestedUrl = ProcessUrlPassedByFeature(requestedUrl);

            //Store Requested URL into scenario context
            ScenarioContext.Current.Add("RequestedUrl", requestedUrl);
            Console.WriteLine("Requested Url was Added to Scenario Context: " + requestedUrl);
        }

        

        [Given(@"A user wants to retrieve a URL from a '(.*)'")]
        public void GivenAUserWantsToRetrieveAURLFromA(string shortCode)
        {
            ScenarioContext.Current.Add("ShortCode", shortCode);
            Console.WriteLine("Short Code was added to Scenario Context: " + shortCode);
        }

        #endregion

        #region When Statements

        [When(@"the requesting service submits a GET request is send for the short-code")]
        public void WhenTheGETRequestIsSendForTheShort_Code()
        {

            //retrieve shortcode from Scenario Context
            string codecEndpoint = "api/codec/" + ScenarioContext.Current["ShortCode"].ToString();

            // get the response from service as a string
            string decoderResponse = GetDecoderResponseAsString(codecEndpoint);
            

            //store response into ScenarioContext
            ScenarioContext.Current.Add("DecoderResponse", decoderResponse);
            Console.WriteLine("Codec Response was added to Scenario Context: " + decoderResponse);

        }

        

        [When(@"the requesting service submits a POST request to encode the URL")]
        public void WhenTheRequestingServiceSubmitsAPOSTRequestToEncodeTheURL()
        {
            HttpClient codecPostClient = GetNewHttpClient();
            Console.WriteLine("Http Client was Created");

            string stringParameters = "{Url:'" + ScenarioContext.Current["RequestedUrl"].ToString() + "'}";
            Console.WriteLine("POST parameters were generated: " + stringParameters);
            //execute request
            HttpResponseMessage codecResponse = codecPostClient.PostAsync("api/codec", new StringContent(stringParameters, Encoding.UTF8, "application/json")).Result;

            //An entry was added to the database, mark it for removal
            int entriesAdded = 1;
            ScenarioContext.Current.Add("EntriesAdded", entriesAdded);
            Console.WriteLine(" Entries Added to the Database: " + entriesAdded.ToString());
            //store response into ScenarioContext
            ScenarioContext.Current.Add("CodecResponse", codecResponse);
            Console.WriteLine("Codec Response was added to Scenario Context: " + codecResponse);
        }

        #endregion

        #region Then Statements

        [Then(@"the codec service returns a code and '(.*)' status")]
        public void ThenTheCodecServiceReturnsACodeAndStatus(string statusMessage)
        {
            var codecResponse = (HttpResponseMessage)ScenarioContext.Current["CodecResponse"];
            string responseContent = codecResponse.Content.ReadAsStringAsync().Result;


            Assert.AreEqual(System.Net.HttpStatusCode.OK, codecResponse.StatusCode, "FAILED: The HTTP Status code was not 'OK'");
            Assert.IsTrue(responseContent.Contains(statusMessage), "FAILED: An incorrect response content was returned: " + responseContent);
                        
        }
                            
        [Then(@"the codec service returns the URL '(.*)'")]
        public void ThenTheCodecServiceReturnsTheURL(string urlRequested)
        {
            var responseContent = (string)ScenarioContext.Current["DecoderResponse"];

            Assert.IsTrue(responseContent.Contains(urlRequested), "FAILED: An incorrect response content was returned: " + responseContent);
        }

        #endregion

    }
}
