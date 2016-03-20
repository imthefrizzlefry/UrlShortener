using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlMini.Models;

namespace UrlMini.Tests.Models
{
    [TestClass]
    public class DataAccessTest
    {
        [TestMethod]
        public void GetDataCount()
        {
            int testInput = DataAccess.GetRecordCount();

            Assert.IsNotNull(testInput);
            Assert.IsTrue(testInput > 0);
        }

        [TestMethod]
        public void RetrieveExampleUrl()
        {
            //request the first index value, which should be set at time of deployment
            string testInput = DataAccess.RetrieveUrl(1);

            //assert the deployed value is correct.
            Assert.AreEqual("home.stevenfarnell.net", testInput);
        }

        [TestMethod]
        public void InsertUrlTest()
        {
            //generate a unique string for test input
            string testInput = "TestInput-" + DateTime.Now.ToString("yyyyMMddHHMM");

            int beforeNumberOfDatabaseRecords = DataAccess.GetRecordCount();

            //execute insertion
            DataAccess.InsertUrl(testInput);



            //retrieve the number of records(the Id for the desired record is the same number)
            UrlData desiredRecord = DataAccess.GetMostRecentRecord();


            // get Url value stored at that ID
            string testOutput = desiredRecord.Url;
            int afterNumberOfDatabaseRecords = DataAccess.GetRecordCount();

            //Assert the value is correct
            Assert.AreEqual(testInput, testOutput, "The value retrieved was not the value entered.");
            Assert.IsTrue((beforeNumberOfDatabaseRecords < afterNumberOfDatabaseRecords), "The record count did not increase after insertion.");

            //cleanup
            DataAccess.RemoveRecord(desiredRecord.UrlId);

            // only do this if you really want to wipe out the entire database!
            //CleanupDatabase();
        }

        //This wipes out all but the first record in the database!!!
        private void CleanupDatabase()
        {
            //retrieve the number of records in the database
            int numRecords = DataAccess.GetRecordCount();

            if (numRecords >= 2)
            {
                for (int counter = 1; counter < numRecords; counter++)
                {
                    //cleanup
                    DataAccess.RemoveRecord(DataAccess.GetMostRecentRecordId());
                }
            }
        }
    }
}
