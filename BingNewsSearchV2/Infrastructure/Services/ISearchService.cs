using BingNewsSearchV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingNewsSearchV2.Infrastructure.Services
{
    public interface ISearchService
    {
        Task<BingJson> MakeRequestAsync(string keyword, int count, int offset);
    }
}
