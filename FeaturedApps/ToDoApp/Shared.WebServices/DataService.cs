namespace Shared.WebServices
{
    using Newtonsoft.Json;
    using Shared.Core;
    using Shared.Infrastructure.Services;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    public class DataService : IDataService
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Task<IEnumerable<ToDoItem>> GetToDosAsync()
        {
            using (var client = CreateClient())
            {
                return Deserialize(GetJson(client));
            }
        }

        private Task<HttpResponseMessage> GetJson(HttpClient httpClient)
        {
            return httpClient.GetAsync("todos");
        }

        private Task<IEnumerable<ToDoItem>> Deserialize(Task<HttpResponseMessage> task)
        {
            if (task.Exception != null)
            {
                return AsFailedResult();
            }
            var response = task.Result;
            if (task.Result.IsSuccessStatusCode == false)
            {
                return AsFailedResult();
            }
            return response.Content.ReadAsStringAsync().ContinueWith<IEnumerable<ToDoItem>>(nextTask => JsonConvert.DeserializeObject<IEnumerable<ToDoItem>>(nextTask.Result));
        }

        private Task<IEnumerable<ToDoItem>> AsFailedResult()
        {
            IEnumerable<ToDoItem> result = new[] { new ToDoItem { title = "Failed to get items" } };

            return Task.Factory.StartNew(() => result);
        }

        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://jsonplaceholder.typicode.com/")
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
