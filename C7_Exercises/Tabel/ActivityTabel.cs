using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    [Table("ActivityTabel")]
    public class ActivityTabel
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("DueDate")]
        public DateTime DueDate { get; set; }

        [Column("IsCompleted")]
        public bool IsCompleted { get; set; }
    }
}
