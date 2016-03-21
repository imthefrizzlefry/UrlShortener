using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlMini.Models;

namespace UrlMini.Tests.Models
{
    [TestClass]
    public class UrlMinimizerTest
    {
        [TestMethod]
        public void Encode_LowestValidIndexValue()
        {
            int testInput = 1;

            string testOutput = UrlMinimizer.Encode(testInput);

            Assert.AreEqual("1y5a", testOutput);
        }

        [TestMethod]
        public void Encode_HighestValidIndexValue()
        {
            //Assuming Offset is set to 90909
            int testInput = 2147392738; //limited to 2147483647 - UrlMinimizer.Offset because of index limitation

            string testOutput = UrlMinimizer.Encode(testInput);


            Assert.AreEqual("zik0zj", testOutput);
        }

        [TestMethod]
        public void Decode_LowestValidShortCodeValue()
        {
            string testInput = "1y5a";

            int testOutput = UrlMinimizer.Decode(testInput);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void Decode_HighestestValidShortCodeValue()
        {
            string testInput = "zik0zj";

            int testOutput = UrlMinimizer.Decode(testInput);

            Assert.AreEqual(2147392738, testOutput);
        }



        [TestMethod]
        public void AttemptToEncode_BelowValidIndexValues()
        {
            int testInput = 0;

            string testOutput = UrlMinimizer.Encode(testInput);

            Assert.AreEqual("Invalid", testOutput);
        }

        [TestMethod]
        public void AttemptToEncode_AboveValidIndexValues()
        {
            int testInput = 2147392739;

            string testOutput = UrlMinimizer.Encode(testInput);

            Assert.AreEqual("Invalid", testOutput);
        }



        [TestMethod]
        public void AttemptToDecode_BelowValidShortCodeValues()
        {
            string testInput = "1y59";

            int testOutput = UrlMinimizer.Decode(testInput);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void AttemptToDecode_AboveValidShortCodeValues()
        {
            string testInput = "zzzzzz";

            int testOutput = UrlMinimizer.Decode(testInput);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void AttemptToDecode_ShortCodeStringTooLong()
        {
            string testInput = "0000000";

            int testOutput = UrlMinimizer.Decode(testInput);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void AttemptToDecode_ShortCodeStringTooShort()
        {
            string testInput = "00";

            int testOutput = UrlMinimizer.Decode(testInput);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void AttemptToDecode_InvalidShortCode()
        {
            List<string> inputList = new List<string>()
            {
                "ag4j!",
                "asd-b",
                "zzzA",
                "hhh}j",
                "aBc3ff",
                "`fbse",
                "?hopd",
                "'gwno",
                "$bdf",
                "bs+4d",
                "-bar",
                "foo|",
            };
            inputList.Add("000!");
            inputList.Add("zzzA");
            inputList.Add("hhh}");
            inputList.Add("abc/");
            
            foreach (var input in inputList)
            {
                int testOutput = UrlMinimizer.Decode(input);

                Assert.AreEqual(-1, testOutput);
                Console.WriteLine(string.Format("Successfully processed string: {0} - Returned: {1}", input, testOutput.ToString()));
            }            
        }

    }
}
