using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public class DatabaseConnection
    {
        public static SQLiteAsyncConnection Instance;

        private  DatabaseConnection()
        {

        }

        public static SQLiteAsyncConnection GetDBConnection()
        {
       
            if (Instance == null)
            {
                var dbName = "Exercise7";
                var folderpath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var dbPath = Path.Combine(folderpath, dbName);
                Instance = new SQLiteAsyncConnection(dbPath);
                return Instance;
            }
            return Instance;
        }

    }
}
