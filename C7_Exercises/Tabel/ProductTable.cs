
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    [Table("ProductTable")]
    public class ProductTable
    {
        [AutoIncrement]
        [PrimaryKey]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Price")]
        public int Price { get; set; }

        [Column("DiscountPercentage")]
        public double DiscountPercentage { get; set; }

        [Column("Rating")]
        public double Rating { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

        [Column("Brand")]
        public string Brand { get; set; }

        [Column("Category")]
        public string Category { get; set; }

        [Column("Thumbnail")]
        public string Thumbnail { get; set; }

      
    }
 
}
