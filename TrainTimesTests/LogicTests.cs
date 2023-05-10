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
        // HW Commenting these tests out as they aren't relevant and I'm just trying to run a CI/CD pipeline with SonarQube!
        /*
        [TestMethod]
        public async Task GetAllPortlandStreetArrivals()
        {
            List<StationArrival> arrivals = new List<StationArrival>();
            NextTrains nt = new NextTrains();
            arrivals = await nt.GetAllPortlandStreetArrivals();
            Assert.IsTrue(arrivals.Count > 0);
            Assert.AreEqual("940GZZLUGPS", arrivals[0].naptanId);
        }
        [TestMethod]
        public async Task GetPortlandStreetPlatform1Arrivals()
        {
            List<StationArrival> arrivals = new List<StationArrival>();
            NextTrains nt = new NextTrains();
            arrivals = await nt.GetPortlandStreetPlatformsArrivals(3, "Westbound - Platform 1" );
            Assert.IsTrue(arrivals.Count > 0);
            Assert.AreEqual("940GZZLUGPS", arrivals[0].naptanId);
            Assert.AreEqual("Westbound - Platform 1", arrivals[0].platformName);
        }
        [TestMethod]
        public async Task GetPortlandStreetPlatform2Arrivals()
        {
            List<StationArrival> arrivals = new List<StationArrival>();
            NextTrains nt = new NextTrains();
            arrivals = await nt.GetPortlandStreetPlatformsArrivals(3, "Eastbound - Platform 2");
            Assert.IsTrue(arrivals.Count > 0);
            Assert.AreEqual("940GZZLUGPS", arrivals[0].naptanId);
            Assert.AreEqual("Eastbound - Platform 2", arrivals[0].platformName);
        }
        */
    }
}
