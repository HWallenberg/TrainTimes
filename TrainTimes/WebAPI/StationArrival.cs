using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace TrainTimes.WebAPI
{
    public class StationArrival
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        [BindProperty]
        public string id { get; set; }
        public int operationType { get; set; }
        public string vehicleId { get; set; }
        public string naptanId { get; set; }
        public string stationName { get; set; }
        public string lineId { get; set; }
        public string lineName { get; set; }
        public string platformName { get; set; }
        public string direction { get; set; }
        public string bearing { get; set; }
        public string destinationNaptanId { get; set; }
        public string destinationName { get; set; }
        public DateTime timestamp { get; set; }
        public int timeToStation { get; set; }
        public string currentLocation { get; set; }
        public string towards { get; set; }
        [BindProperty]
        public DateTime expectedArrival { get; set; }
        public DateTime timeToLive { get; set; }
        public string modeName { get; set; }
        public Timing timing { get; set; }
    }

    public class Timing
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string countdownServerAdjustment { get; set; }
        public DateTime source { get; set; }
        public DateTime insert { get; set; }
        public DateTime read { get; set; }
        public DateTime sent { get; set; }
        public DateTime received { get; set; }
    }    
}
