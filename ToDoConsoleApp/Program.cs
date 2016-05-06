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
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://todowebapp20160505124210.azurewebsites.net/api/values/4");
            string content = await response.Content.ReadAsStringAsync();
        }
    }
}
