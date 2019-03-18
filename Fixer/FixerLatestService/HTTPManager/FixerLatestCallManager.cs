using System;
using RestSharp;

namespace Fixer.FixerLatestService.HTTPManager
{
    public class FixerLatestCallManager
    {
        readonly IRestClient client;

        public FixerLatestCallManager()
        {
            client = new RestClient(FixerConfig.BaseUrl);
        }

        public string GetLatestRates()
        {
            var request = new RestRequest("/latest" + FixerConfig.ApiUrlMod + FixerConfig.ApiKey);
            var response = client.Execute(request, Method.GET);
            return response.Content;
        }
    }
}
