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

        public async Task<List<StationArrival>> GetAllPortlandStreetArrivals()
        {
            try
            {
                List<StationArrival> arrivals = new List<StationArrival>();
                string stationID = await client.GetStationID("GreatPortland");
                arrivals = await client.GetStationArrivals(stationID);
                return arrivals.OrderBy(a => a.timeToStation).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<StationArrival>> GetPortlandStreetPlatformsArrivals(int numberOfArrivals, string platformName)
        {
            try
            {
                if (numberOfArrivals > 0)
                {
                    List<StationArrival> arrivals = new List<StationArrival>();
                    arrivals = await GetAllPortlandStreetArrivals();
                    return arrivals.Where(a => a.platformName == platformName).Select(a => a).Take(numberOfArrivals).ToList();
                }
                else
                {
                    throw new Exception("Number of arrivals must be more than zero.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
