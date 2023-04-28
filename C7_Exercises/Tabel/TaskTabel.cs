using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    [Table("TaskTabel")]
    public class TaskTabel
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("CompletionDate")]
        public DateTime CompletionDate { get; set;}

        [Column("StartTime")]
        public TimeSpan StartTime { get; set;}

        [Column("EndTime")]
        public TimeSpan EndTime { get; set;}

        [Column("CompletedDate")]
        public string CompletedDate { get; set;}

        [Column("CompletionTime")]
        public string CompletionTime { get; set;}
    }
}
