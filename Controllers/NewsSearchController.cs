using BingNewsSearchV2.Infrastructure.Services;
using BingNewsSearchV2.Models;
using DataTables.AspNet.Core;
using DataTables.AspNet.WebApi2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BingNewsSearchV2.Controllers
{
    public class NewsSearchController : ApiController
    {
        // GET api/NewsSearch?keywords=microsoft&count=10&offset=0
        public async Task<BingJson> Get(string keywords, int count = 10, int offset = 0)
        {
            return await GetSearchResults(keywords, count, offset);
        }

        // GET api/NewsSearch/GetDataTable
        public async Task<JsonResult<IDataTablesResponse>> GetDataTable(IDataTablesRequest request)
        {
            var data = await GetSearchResults(request.Search.Value, request.Length, request.Start);

            var response = DataTablesResponse.Create(request, data.totalEstimatedMatches, data.totalEstimatedMatches, data.value);

            return new DataTablesJsonResult(response, Request);
        }

        private async Task<BingJson> GetSearchResults(string keyword, int count, int offset)
        {
            var searchService = new BingNewsSearchService();
            return await searchService.MakeRequestAsync(keyword, count, offset);
        }
    }
}
