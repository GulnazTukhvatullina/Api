using System;
using System.IO;
using System.Net;
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

            var request = WebRequest.Create(url);

            var response = request.GetResponse();
            var httpStatusCode = (response as HttpWebResponse).StatusCode;

            if (httpStatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine(httpStatusCode);
                return;
            }

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                var temp = JsonConvert.DeserializeObject<Root>(result);
                Console.WriteLine(temp.quote.body);
            }
        }
    }
}
