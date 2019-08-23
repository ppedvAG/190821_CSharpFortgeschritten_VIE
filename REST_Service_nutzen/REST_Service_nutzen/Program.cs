using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace REST_Service_nutzen
{
    class Program
    {
        static async Task Main(string[] args) // seit C# 7.3
        {
            // 1) JSON-String herunterladen

            string json;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            }

            Console.WriteLine(json);

            User[] users = JsonConvert.DeserializeObject<User[]>(json);
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.Title}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
