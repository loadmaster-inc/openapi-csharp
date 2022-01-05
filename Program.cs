using IdentityModel.Client;
using LoadMaster.Share.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Web.Models;

namespace LoadMaster_api_call_sample
{
    class Program
    {
        private const string TokenUrlBase = "https://api.zhuangxiang.com/";
        private const string OpenApiUrlBase = "https://openapi.zhuangxiang.com/";

        static void Main(string[] args)
        {
            RunDemoAsync().Wait();
        }

        public static async Task RunDemoAsync()
        {
            var accessToken = await GetAccessTokenViaOwnerPasswordAsync();

            await GetLoadingTaskDataByName(accessToken,"{ your_loadingTask_name}");
        }

        private static async Task<LoadingTaskDto> GetLoadingTaskDataByName(string accessToken, string taskName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(OpenApiUrlBase);

                client.SetBearerToken(accessToken);

                var response = await client.GetAsync($"/loadingtask/GetLoadingTaskByName?name={taskName}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var ajaxResponse  = JsonConvert.DeserializeObject<AjaxResponse<LoadingTaskDto>>(content);

                var taskData = ajaxResponse.Result;

                Console.WriteLine("GetData succed!");
                Console.WriteLine($"Task name is {taskData.Name}");
                Console.WriteLine($"Packed Containers: {taskData.PackedUnits.Count()}");

                return taskData;
            }
        }

        /// <summary>
        /// 在获取token之前，需要先到 https://app.zhuangxiang.com 注册租户， 登陆程序，在 OpenApi 页面，注意你的 app，然后就可以通过获取的 appId，appSecret 来获取token。
        /// </summary>
        /// <returns></returns>
        private static async Task<string> GetAccessTokenViaOwnerPasswordAsync()
        {
            using (var httpHandler = new HttpClientHandler())
            {
                httpHandler.CookieContainer.Add(new Uri(TokenUrlBase), new System.Net.Cookie("Abp.TenantId", "{your tenant id}"));  //Set TenantId  

                using (var client = new HttpClient(httpHandler))
                {
                    var disco = await client.GetDiscoveryDocumentAsync(TokenUrlBase);

                    var tokenEndPoint = disco.TokenEndpoint;
                    
                    var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
                    {
                        Address = disco.TokenEndpoint,
                        ClientId = "{ your app }",
                        ClientSecret = "{your app secret}",
                        Scope = "Integrate_Api",
                        GrantType = "password",
                        UserName = "{your username}",
                        Password = "{your password}"
                    });

                    if (!tokenResponse.IsError)
                        return tokenResponse.AccessToken;
                }
            }

            return null;

        }


    }
}
