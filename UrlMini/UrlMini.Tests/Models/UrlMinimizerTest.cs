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
        public void EncodeLowestValidIndexValue()
        {
            int testInput = 1;

            string testOutput = UrlMinimizer.Encode(testInput);

            Assert.AreEqual("1y5a", testOutput);
        }

        [TestMethod]
        public void EncodeHighestValidIndexValue()
        {
            //Assuming Offset is set to 90909
            int testInput = 2147392738; //limited to 2147483647 - UrlMinimizer.Offset because of index limitation

            string testOutput = UrlMinimizer.Encode(testInput);


            Assert.AreEqual("zik0zj", testOutput);
        }
    }
}
