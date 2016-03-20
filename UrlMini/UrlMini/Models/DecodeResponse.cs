using System;
using System.Runtime.Serialization;

namespace UrlMini.Models
{
    [Serializable]
    [DataContract]
    public class DecodeResponse
    {
        [DataMember]
        public string Url;

        public DecodeResponse()
        { }

        public DecodeResponse(string url)
        {
            this.Url = url;
        }
    }
}