namespace DobrfDownloadModule
{
    using DobrfDownloadModule.DobrfModels;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DobrfDownloader
    {
        public volunteers GetVolunteers()
        {
            var client = new RestClient("https://api.dobrf.ru");
            var request = new RestRequest("open-api/v1/volunteers", Method.GET);
            request.AddHeader("accept", "application/json");
            request.AddParameter("page_size", 500);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<volunteers>(content);
            return result;
        }
    }
}
