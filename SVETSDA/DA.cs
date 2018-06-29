using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace SVETSDA
{
    public class DA
    {
        private HttpClient client = new HttpClient();

        public DA()
        {
            client.BaseAddress = new Uri("http://svets.azurewebsites.net/api/");
        }

        public async Task<string> GetEntitiesAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            string entities = await response.Content.ReadAsStringAsync();

            return entities;
        }

        public async void PutEntityAsync(string path, dynamic arg)
        {
            string payload = JsonConvert.SerializeObject(arg);
            HttpContent httpPayload = new StringContent(payload, UnicodeEncoding.UTF8, "application/json");

            await client.PutAsync(path, httpPayload);
        }

        public async void PostEntityAsync(string path, dynamic arg)
        {
            string payload = JsonConvert.SerializeObject(arg);
            HttpContent httpPayload = new StringContent(payload, UnicodeEncoding.UTF8, "application/json");

            await client.PostAsync(path, httpPayload);
        }

        public async void DeleteEntityAsync(string path)
        {
            await client.DeleteAsync(path);
        }
    }
}
