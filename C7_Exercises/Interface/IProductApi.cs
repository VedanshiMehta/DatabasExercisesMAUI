using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public interface IProductApi
    {
        [Get("/products")]
        Task<HttpResponseMessage> GetProductsList();
    }
}
