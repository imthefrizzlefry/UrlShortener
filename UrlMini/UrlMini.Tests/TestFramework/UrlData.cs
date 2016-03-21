using System;
using System.Runtime.Serialization;

namespace UrlMini.Tests.TestFramework
{
    [Serializable]
    [DataContract]
    public class UrlData
    {
        public int UrlId { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
    }
}