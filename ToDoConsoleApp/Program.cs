using ToDoWebApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();
        }

        public async static Task Execute()
        {
            //ToDo todo = new ToDo { Key = "a8dacc6a-bb62-4f25-9f87-eac798ef831d", Name = "Hi", IsComplete = true }; //For update
            ToDo todo = new ToDo { Name = "Be awesome", IsComplete = false }; // For create
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(todo);
            HttpContent content  = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpClient client = new HttpClient();
            //var response = await client.GetAsync("http://todowebapp20160505124210.azurewebsites.net/api/todo");
            var response = await client.PostAsync("http://todowebapp20160505124210.azurewebsites.net/api/todo", content );
            //var response = await client.PutAsync("http://todowebapp20160505124210.azurewebsites.net/api/todo/a8dacc6a-bb62-4f25-9f87-eac798ef831d", content);
            string reponseFromServer = await response.Content.ReadAsStringAsync();
        }
    }
}
