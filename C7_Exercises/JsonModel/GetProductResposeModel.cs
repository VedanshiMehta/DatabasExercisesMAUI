using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public class GetProductResposeModel
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("discountPercentage")]
        public double DiscountPercentage { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }
    }

}
