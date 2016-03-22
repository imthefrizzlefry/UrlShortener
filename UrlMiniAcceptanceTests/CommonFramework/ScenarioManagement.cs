using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace CommonFramework
{
    public class ScenarioManagement
    {
        public static void AddPreTestRecordCountToScenarioContext()
        {
            //retrieve number of records currently in database
            int recordCount = DataAccess.GetRecordCount();

            //store number of records into ScenarioContext
            ScenarioContext.Current.Add("PreRecordCount", recordCount);
            Console.WriteLine("Pre Record Count was added to Scenario Context: " + recordCount);
        }

        public static void RemoveRecordsAddedToTheDatabase()
        {
            //retrieve number of records currently in database
            int postRecordCount = DataAccess.GetRecordCount();
            int preRecordCount = (int)ScenarioContext.Current["PreRecordCount"];


            if (ScenarioContext.Current.ContainsKey("EntriesAdded") && postRecordCount > preRecordCount)
            {
                int entriesAdded = (int)ScenarioContext.Current["EntriesAdded"];

                Assert.AreEqual(entriesAdded, (postRecordCount - preRecordCount), "FAIL: The incorrect number or records were added!");

                for (int counter = 1; counter <= (int)ScenarioContext.Current["EntriesAdded"]; counter++)
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
    }
}
