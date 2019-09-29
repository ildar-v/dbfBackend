namespace DobrfDownloadModule
{
    using DobrfDownloadModule.DobrfModels;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
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

        public List<@event> GetEvents()
        {
            var client = new RestClient("https://api.dobrf.ru");
            var request = new RestRequest("open-api/v1/events", Method.GET);
            request.AddHeader("accept", "application/json");
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<events>(content);

            List<@event> events = new List<@event>();

            foreach (var item in result.results)
            {
                var request1 = new RestRequest("open-api/v1/events/" + item.id, Method.GET);
                request.AddHeader("accept", "application/json");
              //  request.AddParameter("id", item.id);
                IRestResponse response1 = client.Execute(request1);
                var content1 = response1.Content;
                var result1 = JObject.Parse(content1);

                item.description = result1["description"].Value<string>();

                events.Add(item);
            }

            return events;
        }
    }
}
