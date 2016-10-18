using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectWpfAppExpVersion
{
    public class Response
    {
        public class Image
        {
            public string src { get; set; }
            public string alt { get; set; }
            public string href { get; set; }
        }

        public class Description
        {
            public string text { get; set; }
            public string href { get; set; }
        }

        public class Detail
        {
            public string text { get; set; }
        }

        public class Flag
        {
            public string src { get; set; }
            public string alt { get; set; }
            public string title { get; set; }
        }

        public class Price
        {
            public string text { get; set; }
            public string href { get; set; }
        }

        public class BidCount
        {
            public string text { get; set; }
            public string href { get; set; }
        }

        public class Dealer
        {
            public string src { get; set; }
            public string alt { get; set; }
        }

        public class BuyNow
        {
            public string text { get; set; }
        }

        public class Group
        {
            public List<Image> Image { get; set; }
            public List<Description> Description { get; set; }
            public List<Detail> Details { get; set; }
            public List<Flag> Flags { get; set; }
            public List<Price> Price { get; set; }
            public List<BidCount> BidCount { get; set; }
            public List<Dealer> Dealer { get; set; }
            public List<BuyNow> BuyNow { get; set; }
        }

        public class Datum
        {
            public List<Group> group { get; set; }
        }

        public class ExtractorData
        {
            public string url { get; set; }
            public string resourceId { get; set; }
            public List<Datum> data { get; set; }
        }

        public class PageData
        {
            public string resourceId { get; set; }
            public int statusCode { get; set; }
            public long timestamp { get; set; }
        }

        public class RootObject
        {
            public ExtractorData extractorData { get; set; }
            public PageData pageData { get; set; }
            public string url { get; set; }
            public string runtimeConfigId { get; set; }
            public long timestamp { get; set; }
            public int sequenceNumber { get; set; }
        }

    }
}
