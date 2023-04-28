using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public class GetActivitiesEndpoint
    {
        public async Task<HttpResponseMessage> ExecuteActivityAsync()
        {
            return await RestService.For<IActivityApi>("https://fakerestapi.azurewebsites.net/api/v1").GetActivitesList();
        }
    }
}
