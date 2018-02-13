using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TangentHR.Models;

namespace TangentHR.Services
{
    public class ApiServices
    {
        public ApiServices()
        {
        }

        public async Task<Auth> SignInAsync(string username, string password)
        {

            var signInModel = new Login
            {
                Username = username,
                Password = password
            };

            var keyValues = new List<KeyValuePair<string,
             string>> {
     new KeyValuePair < string,
                string > ("username", Constants.Username),
     new KeyValuePair < string,
                string > ("password", Constants.Password)
    };

            var request = new HttpRequestMessage(HttpMethod.Post, Constants.BaseUrl + "/api-token-auth/");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            System.Diagnostics.Debug.WriteLine(await response.Content.ReadAsStringAsync());

            return JsonConvert.DeserializeObject<Auth>(await response.Content.ReadAsStringAsync());
        }

        public async Task<UserProfile> GetProfileAsync(string token)
        {

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);

            var jsonResponse = await client.GetStringAsync(Constants.BaseUrl + "/api/user/me/");

            var userProfile = JsonConvert.DeserializeObject<UserProfile>(jsonResponse);

            return userProfile;
        }
    }
}
