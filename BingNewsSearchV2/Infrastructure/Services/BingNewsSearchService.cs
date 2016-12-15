using BingNewsSearchV2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BingNewsSearchV2.Infrastructure.Services
{
    public class BingNewsSearchService : ISearchService
    {
        public async Task<BingJson> MakeRequestAsync(string keyword, int count, int offset)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "your bing search api key");

            // Request parameters
            queryString["q"] = keyword;
            queryString["count"] = count.ToString();
            queryString["offset"] = offset.ToString();
            queryString["mkt"] = "en-us";
            queryString["safeSearch"] = "Moderate";
            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/news/search?" + queryString;

            var response = await client.GetStringAsync(uri);
            return JsonConvert.DeserializeObject<BingJson>(response);
        }
    }
}