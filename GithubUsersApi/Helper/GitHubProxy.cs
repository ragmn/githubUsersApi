using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubUsersApi.Helper
{
    public class GitHubProxy
    {
        public static async Task<T> GetAsync<T>(string uri)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "githubUsersApi");
                    var response = await client.GetAsync($"{uri}");
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}