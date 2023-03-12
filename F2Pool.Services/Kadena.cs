using F2Pool.Services.Utilities;
using HashRates.Models;
using HashRates.Utilities;
using Integration;
using System.Text;

namespace HashRates.F2Pool
{
    public class Kadena : IPoolHashRate
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly IIntegrationService _integrationService;
        private const string BASE_URL = "https://api.f2pool.com/";
        private const string VERSION = "v2";
        private const string API_KEY = "F2P-API-SECRET";

        public Kadena()
        {
            string token = Account.GetToken();            
            
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Invalid or Missing Token");
            }
            else
            {
                _integrationService = new IntegrationService(BASE_URL, API_KEY, token, VERSION);
            }
        }

        public async Task<MinerUserInfo> GetAccountInformationAsync()
        {
            string username = Account.GetUsername();

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Invalid or Missing Miner Username");
            }
            else
            {
                try
                {
                    F2PoolRequest request = new() { mining_user_name = username };
                    MinerUserInfo response = await _integrationService.PostAsync<F2PoolRequest, MinerUserInfo>("mining_user/get", request);
                    return response;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    throw;
                }
            }
        }

        //TODO:  This is not yet implemented and tested.
        public async Task<string> GetHashRateAsync(string minerUsername)
        {
            string token = ConfigHelper.GetAppSetting(Constants.F2POOL_TOKEN);
            httpClient.DefaultRequestHeaders.Add("F2P-API-SECRET", token);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue())

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.f2pool.com/v2/hash_rate/worker/history");
            request.Content = new StringContent(
                "{\"mining_user_name\":\"" + minerUsername +"\"}, \"{\"address\":}, \"{\"currency\":}, \"{\"worker_name\":, \"interval\":60, \"duration\":60}", 
                Encoding.UTF8, 
                "application/json");
            //request.Content = new StringContent("", Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                HttpContent content = httpResponseMessage.Content;
                return await content.ReadAsStringAsync();
            }
            else
                return "Invalid Request";
        }
    }
}
