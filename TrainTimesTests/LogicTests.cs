using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTimes.WebAPI;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrainTimes.Logic;

namespace TrainTimesTests
{
    [TestClass]
    public class LogicTests
    {
        
        [TestMethod]
        public async Task GetAllPiccadillyArrivals()
        {
            Dictionary<string,List<StationArrival>> arrivals = new Dictionary<string, List<StationArrival>>();
            StationArrivals nt = new StationArrivals();
            arrivals = await nt.GetPlatformsArrivals("piccadilly");
            Assert.IsTrue(arrivals.Count > 0);
            Assert.IsTrue(arrivals.ContainsKey("Northbound - Platform 1"));
            Assert.AreEqual("940GZZLUPCC", arrivals["Northbound - Platform 1"][0].naptanId);
        }

        [TestMethod]
        public async Task GetAllOxfordStreetArrivals()
        {
            Dictionary<string, List<StationArrival>> arrivals = new Dictionary<string, List<StationArrival>>();
            StationArrivals nt = new StationArrivals();
            arrivals = await nt.GetPlatformsArrivals("oxford");
            Assert.IsTrue(arrivals.Count > 0);
            Assert.IsTrue(arrivals.ContainsKey("Southbound - Platform 3"));
            Assert.AreEqual("940GZZLUOXC", arrivals["Southbound - Platform 3"][0].naptanId);
        }

    }
}