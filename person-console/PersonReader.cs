
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace person_console
{
    public class PersonReader
    {
        private HttpClient _client = new HttpClient();

        public PersonReader()
        {
            _client.BaseAddress = new Uri("http://localhost:9874");
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Person>> GetAsync()
        {
            await Task.Delay(3000);

            HttpResponseMessage response = await _client.GetAsync("people");
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Person>>(stringResult);
            }
            return new List<Person>();
        }
    }
}