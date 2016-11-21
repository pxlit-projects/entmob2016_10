using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Domain;
using System.Net.Http.Headers;
using System.Diagnostics;
using Newtonsoft.Json;

namespace App1.DAL
{
    public class App1Repository : IApp1Repository
    {
        private string baseUri = "http://192.168.43.253:8090/";
        private User user;
        private List<User> users;

        public async Task<User> GetUserById(int id)
        {
            var url = baseUri + "User/getUserById/" + id;

            string json = await JsonApiClientGetRequest(url);
            if (json != null)
            {
                user = JsonConvert.DeserializeObject<User>(json);
                return user;
            }
            return null;
        }

        public async Task<List<User>> GetUsers()
        {
            var url = baseUri + "User/getUsers";

            string json = await JsonApiClientGetRequest(url);
            if (json != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(json);
                return users;
            }
            return null;
        }

        public async Task<string> JsonApiClientGetRequest(string baseUri)
        {
            string json = null;
            string username = "1";
            string password = "secret";
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    string authenticationLogin = Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password));
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", authenticationLogin));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(baseUri);
                    if (response.IsSuccessStatusCode)
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }

                    return json;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error jsonApiClientRequest : " + ex.Message);
            }

            return null;
        }
    }
}
