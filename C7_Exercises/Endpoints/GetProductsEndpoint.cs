using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public class GetProductsEndpoint
    {
        public Task<HttpResponseMessage> GetProductListAsync()
        {
            return RestService.For<IProductApi>("https://dummyjson.com").GetProductsList();
        }
    }
}
