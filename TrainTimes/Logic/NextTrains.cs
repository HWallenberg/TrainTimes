using System;
using System.Collections.Generic;
using System.Linq;
using TrainTimes.WebAPI;

namespace TrainTimes.Logic
{
    public class NextTrains
    {
        private TFLClient client { get; set; }
        public NextTrains() 
        {
            client = new TFLClient(@"https://api.tfl.gov.uk");
        }

        public async Task<Dictionary<string, List<StationArrival>>> GetPlatformsArrivals()
        {
            try
            {   
                Dictionary<string, List<StationArrival>> platformsArrivals = new Dictionary<string, List<StationArrival>>();
                platformsArrivals = await client.GetStationPlatformArrivals("portland");
                return platformsArrivals;   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
