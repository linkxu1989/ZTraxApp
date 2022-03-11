using System;
using System.ComponentModel;

namespace ZTraxApp.Models
{
    internal class Tags
    {
        public string TagId { get; set; }
        public string Last6 { get; set; }
        public DateTime TimeStamp { get; set; }

        public Tags(string tagId, string last6, DateTime timeStamp)
        {
            TagId = tagId;
            Last6 = last6;
            TimeStamp = timeStamp;
        }

        public override string ToString()
        {
            return TagId + " - " + Last6 + " " + TimeStamp.ToLongTimeString();
        }
    }
}

