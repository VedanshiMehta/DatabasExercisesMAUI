using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public interface IActivityApi
    {
        [Get("/Activities")]
        Task<HttpResponseMessage> GetActivitesList();
    }
}
