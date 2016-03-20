using System;
using System.Runtime.Serialization;

namespace UrlMini.Models
{
    [Serializable]
    [DataContract]
    public class EncodeRequest
    {
        [DataMember]
        public string Url;
    }
}