using System;
using System.Runtime.Serialization;

namespace UrlMini.Models
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