using Newtonsoft.Json;
namespace TrainTimes.WebAPI
{
    public class Match
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string icsId { get; set; }
        public string topMostParentId { get; set; }
        public List<string> modes { get; set; }
        public string zone { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class SearchResult
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string query { get; set; }
        public int total { get; set; }
        public List<Match> matches { get; set; }
    }
}
