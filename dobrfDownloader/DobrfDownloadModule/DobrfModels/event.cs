namespace DobrfDownloadModule.DobrfModels
{
    using System;

    public class @event
    {
        public int id { get; set; }
        public photo image { get; set; }
        public author author { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
