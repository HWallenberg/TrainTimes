using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Web;

namespace TrainTimes.WebAPI
{
    public class TflClient
    {
        private readonly HttpClient _client;

        public TflClient(string TFLBaseURL)
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
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
           
        }

        public async Task<string> GetStationID(string stationName)
        {
            SearchResult? searchResult = new SearchResult();
            string? stationId = string.Empty;
            try
            {
                string requestParams = @"Stoppoint/Search/" + stationName + @"?modes=tube";
                HttpResponseMessage response = await Client.GetAsync(requestParams);
                searchResult = JsonConvert.DeserializeObject<SearchResult>(response.Content.ReadAsStringAsync().Result);
                if (searchResult != null)
                {
                    if (searchResult.matches != null)
                    {
                        if (searchResult.matches.Count == 1)
                        {
                            stationId = searchResult.matches[0].id;
                        }
                    }
                    else
                    {
                        stationId = "There was not an exact match for station name";
                    }
                }
                else
                {
                    throw new ArgumentNullException("Cannot find a NaptanID for Station Name: " + stationName);
                }
            }
            catch (JsonSerializationException ex)
            {
                throw new JsonSerializationException(ex.Message);
            }
            if (stationId != null)
            {
                return stationId;
            }
            else
            {
                throw new ArgumentNullException("Station Name could not be found" + stationName);
            }
        }

        public async Task<Dictionary<string, List<StationArrival>>> GetStationPlatformArrivals(string stationName)
        {
            List<StationArrival>? arrivals = new List<StationArrival>();
            Dictionary<string, List<StationArrival>> platformArrivals;
            string stationID = await GetStationID(stationName);
            try
            {
                string requestParams = @"StopPoint/" + stationID + @"/Arrivals?mode=tube";
                HttpResponseMessage response = await Client.GetAsync(requestParams);
                arrivals = JsonConvert.DeserializeObject<List<StationArrival>>(response.Content.ReadAsStringAsync().Result) ;

                if (arrivals != null)
                {
                    platformArrivals = new Dictionary<string, List<StationArrival>>();
                    foreach (StationArrival _arrival in arrivals)
                    {
                        if (_arrival.platformName != null)
                        {
                            if (!platformArrivals.ContainsKey(_arrival.platformName))
                            {
                                List<StationArrival> stationArrivals = arrivals.Where(a => a.platformName == _arrival.platformName).ToList();

                                platformArrivals.Add(_arrival.platformName, stationArrivals);
                            }
                            else
                            {
                                List<StationArrival> stationArrivals = platformArrivals[_arrival.platformName];
                                stationArrivals.Add(_arrival);
                                platformArrivals[_arrival.platformName] = stationArrivals;
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentNullException("There are no Station Arrivals to show for NaptanID: " + stationID + " Station Name: " + stationName);
                }
            }
            
            catch (JsonSerializationException ex)
            {
                throw new JsonSerializationException(ex.Message);
            }

            return platformArrivals;
            
        }
    }
}

