using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramework
{
    public static class CommonMethods
    {
        public static string ProcessUrlPassedByFeature(string requestedUrl)
        {
            //insert a timestamp to make test entry unique      
            if (requestedUrl.Contains("<TIMESTAMP>"))
            {
                string currentTime = DateTime.Now.ToString("yyyyMMddHHMM");
                requestedUrl = requestedUrl.Replace("<TIMESTAMP>", currentTime);
            }

            return requestedUrl;
        }
    }
}
