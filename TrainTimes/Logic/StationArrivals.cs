using System;
using System.Collections.Generic;
using System.Linq;
using TrainTimes.WebAPI;

namespace TrainTimes.Logic
{
    public class StationArrivals
    {
        private TFLClient client { get; set; }
        public StationArrivals() 
        {
            client = new TFLClient(@"https://api.tfl.gov.uk");
        }

        public async Task<Dictionary<string, List<StationArrival>>> GetPlatformsArrivals(string stationName)
        {
            try
            {   
                Dictionary<string, List<StationArrival>> platformsArrivals = new Dictionary<string, List<StationArrival>>();
                platformsArrivals = await client.GetStationPlatformArrivals(stationName);
                return platformsArrivals;   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
