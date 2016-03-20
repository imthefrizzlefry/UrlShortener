using System;
using System.Runtime.Serialization;

namespace UrlMini.Models
{
    [Serializable]
    [DataContract]
    public class EncodeResponse
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Status { get; set; }

    }
}