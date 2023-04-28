using C7_Exercises.View.Exercise4;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public static class UserDatabase
    {
 
        public static async Task CreateTabelAsync()
        {
            try
            {
                  
               var resultUserTabel = await DatabaseConnection.GetDBConnection().CreateTableAsync<UserDetailTabel>();
               var resultAcitiviyTabel = await DatabaseConnection.GetDBConnection().CreateTableAsync<ActivityTabel>();
               var resultTaskTabel = await DatabaseConnection.GetDBConnection().CreateTableAsync<TaskTabel>();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public static async Task<bool> InsertData<T>(T t)
        {
            if (t != null)
            {
                try
                {
                    var result = await DatabaseConnection.GetDBConnection().InsertAsync(t);
                    if (result > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.InnerException?.Message);
                    return false;
                }
            }
            return false;
        }
        public static async Task<bool> DeleteData<T>(T t)
        {
            if (t != null)
            {
                try
                {
                    var result = await DatabaseConnection.GetDBConnection().DeleteAsync(t);
                    if (result > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.InnerException?.Message);
                    return false;
                }
            }
            return false;
        }
        public static async Task<bool> UpdateData<T>(T t)
        {
            if (t != null)
            {
                try
                {
                    var result = await DatabaseConnection.GetDBConnection().UpdateAsync(t);
                    if (result > 0)
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting data: " + ex.InnerException?.Message);
                    return false;
                }
            }
            return false;
        }

        public static async Task<List<UserDetailTabel>> GetUserRegisteredDetail()
        {
            try
            {
                return await DatabaseConnection.GetDBConnection().Table<UserDetailTabel>().ToListAsync();
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.InnerException?.Message);
                return null;
            }
           
        }
        public static async Task<List<ActivityTabel>> GetActivityDetail()
        {
            try
            {
                return await DatabaseConnection.GetDBConnection().Table<ActivityTabel>().ToListAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.InnerException?.Message);
                return null;
            }

        }
        public static async Task<List<TaskTabel>> GetTaskDetail()
        {
            try
            {
                return await DatabaseConnection.GetDBConnection().Table<TaskTabel>().ToListAsync();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.InnerException?.Message);
                return null;
            }

        }




    }
}
