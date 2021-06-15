using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Api
{
    class Program
    {
        public class Quote
        {
            public int id { get; set; }
            public bool dialogue { get; set; }
            public bool @private { get; set; }
            public List<string> tags { get; set; }
            public string url { get; set; }
            public int favorites_count { get; set; }
            public int upvotes_count { get; set; }
            public int downvotes_count { get; set; }
            public string author { get; set; }
            public string author_permalink { get; set; }
            public string body { get; set; }
        }

        public class Root
        {
            public DateTime qotd_date { get; set; }
            public Quote quote { get; set; }
        }

        static void Main(string[] args)
        {
            var title = Console.ReadLine();
            var url = $"https://favqs.com/api/qotd";


            Console.WriteLine("Hello World!");
        }
    }
}
