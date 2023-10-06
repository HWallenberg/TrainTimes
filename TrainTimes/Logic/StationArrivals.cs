using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TrainTimes.WebAPI;

namespace TrainTimes.Logic
{
    public class StationArrivals
    {
        private TflClient client { get; set; }
        public StationArrivals() 
        {
            client = new TflClient(@"https://api.tfl.gov.uk");
        }

        public async Task<Dictionary<string, List<StationArrival>>> GetPlatformsArrivals(string stationName)
        {
            try
            {   
                Dictionary<string, List<StationArrival>> platformsArrivals = await client.GetStationPlatformArrivals(stationName);
                return platformsArrivals;   
            }
            catch (JsonSerializationException ex)
            {
                throw new JsonSerializationException(ex.Message);
            }
        }

    }
}
