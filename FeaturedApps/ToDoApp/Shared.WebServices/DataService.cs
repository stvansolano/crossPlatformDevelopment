namespace Shared.WebServices
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Shared.Core;
    using Shared.Infrastructure.Services;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

	public class DataService : IDataService
	{
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Task<IEnumerable<ToDoItem>> GetToDosAsync()
        {
            using (var client = new HttpClient())
            {
                return Task.Run(() => Deserialize(GetJson(client).Result));
            }
        }

        private Task<string> GetJson(HttpClient client)
        {
            return client.GetStringAsync("http://jsonplaceholder.typicode.com/todos").ContinueWith(task => HandleResult(task));
        }

        private string HandleResult(Task<string> task)
        {
            //task => task.Result.Content.ReadAsStringAsync()
            if (task.Exception == null)
            {
                //var result = task.Result.Content.ReadAsStringAsync();
                return task.Result;
            }
            return "[{'userId': 1, 'id': 1,'title': 'Failed to get items','completed': false}]";
        }
       
        private IEnumerable<ToDoItem> Deserialize(string result)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<ToDoItem>>(result);
            }
            catch (System.Exception ex)
            {
            }

            return new ToDoItem[0];
        }
    }
}
