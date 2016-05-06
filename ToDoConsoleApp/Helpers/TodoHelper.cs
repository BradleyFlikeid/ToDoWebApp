using System;
using System.Data;
using System.Data.SqlClient;
using ToDoWebApp.Models;

namespace ToDoConsoleApp.Helpers
{
    public class TodoHelper
    {


        public static bool SaveTodoItem(ToDo todo)
        {
            bool result = false;
            try
            {
                using (var connection = new SqlConnection("Server=tcp:dsnsjnb8bm.database.windows.net,1433;Database=ToDoWebApp20160505124210_db;User ID=bradleyflikeid@dsnsjnb8bm;Password=Derpderpmerr22;"))
                {
                    var command = new SqlCommand("SaveTodoItem", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@text", todo.Name);
                    command.Parameters.AddWithValue("@complete", todo.IsComplete);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                var error = ex;
            }

            result = true;
            return result;
        }
    }
}
