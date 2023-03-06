using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace TrainTimes.WebAPI
{
    public class TFLClient
    {
        private HttpClient _client;

        public TFLClient(string TFLBaseURL)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(TFLBaseURL);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpClient Client
        {
            get { return _client; }
        }

        public async Task<bool> connectToTFLService()
        {
            try
            {
                string requestParams = @"/stoppoint/search/meta/categories";
                HttpResponseMessage response = await Client.GetAsync(requestParams);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<string> GetStationID(string stationName)
        {
            SearchResult searchResult = new SearchResult();
            string stationId = string.Empty;
            try
            {
                string requestParams = @"Stoppoint/Search/" + stationName + @"?modes=tube";
                HttpResponseMessage response = await Client.GetAsync(requestParams);
                searchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content.ReadAsStringAsync().Result);
                if (searchResult.matches.Count == 1)
                {
                    stationId = searchResult.matches[0].id;
                }
                else
                {
                    stationId = "There was not an exact match for station name";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stationId;
        }

        public async Task<List<StationArrival>> GetStationArrivals(string stationID)
        {
            List<StationArrival> arrivals = new List<StationArrival>();
            try
            {
                string requestParams = @"StopPoint/" + stationID + @"/Arrivals?mode=tube";
                HttpResponseMessage response = await Client.GetAsync(requestParams);
                arrivals = JsonConvert.DeserializeObject<List<StationArrival>>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return arrivals;
        }
    }
}

