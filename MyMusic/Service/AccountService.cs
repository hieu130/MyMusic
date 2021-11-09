using MyMusic.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Service
{
    public class AccountService
    {
        private static string ApiBaseUrl = "https://music-i-like.herokuapp.com";
        private static string ApiAccountPath = "/api/v1/accounts";
        private static string ApiAccountLoginPath = "/api/v1/accounts/authentication";
        private static string ApiDataType = "application/json";
        public async Task<bool> Register(Account account)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(account);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    var result = await client.PostAsync(ApiAccountPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public async Task<bool> Login(string loginEmail, string loginPassword)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Debug.WriteLine($"Email: {loginEmail}");
                    Debug.WriteLine($"Password: {loginPassword}");
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    var loginInformation = new
                    {
                        email = loginEmail,
                        password = loginPassword
                    };
                    var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(loginInformation);
                    var contentToSend = new StringContent(jsonContent, Encoding.UTF8, ApiDataType);
                    Debug.WriteLine(contentToSend.ToString());
                    var result = await client.PostAsync(ApiAccountLoginPath, contentToSend);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine(resultContent);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

}
