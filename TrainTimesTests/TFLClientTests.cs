using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTimes.WebAPI;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TrainTimesTests
{
    [TestClass]
    public class TFLClientTests
    {
        TFLClient client { get; set; }
        public TFLClientTests()
        {
            client = new TFLClient(@"https://api.tfl.gov.uk");
        }

        [TestMethod]
        public async Task ConnectToTFLWebAPI()
        {
            bool success = false;
            success = await this.client.connectToTFLService();
            Assert.IsTrue(success, "Failed to connect.");
        }
        [TestMethod]
        public async Task GetStationID_Success()
        {
            string stationName = "GreatPortland";
            string stationID = string.Empty;
            stationID = await this.client.GetStationID(stationName);
            Assert.AreEqual("940GZZLUGPS", stationID);
        }
        [TestMethod]
        public async Task GetStationID_Fail()
        {
            string stationName = "sggggewgwgweew";
            string stationID = string.Empty;
            stationID = await this.client.GetStationID(stationName);
            Assert.AreNotEqual("940GZZLUGPS", stationID);
        }
        [TestMethod]
        public async Task GetStationArrivals()
        {
            List<StationArrival> arrivals = new List<StationArrival>();
            string stationName = "GreatPortland";
            string stationID = string.Empty;
            stationID = await this.client.GetStationID(stationName);
            arrivals = await this.client.GetStationArrivals(stationID);
            Assert.IsTrue(arrivals.Count > 0);
            Assert.AreEqual("940GZZLUGPS", arrivals[0].naptanId);
        }

        [TestMethod]
        public async Task GetOxfordCirusArrivals()
        {
            List<StationArrival> arrivals = new List<StationArrival>();
            string stationName = "Oxford";
            string stationID = string.Empty;
            stationID = await this.client.GetStationID(stationName);
            arrivals = await this.client.GetStationArrivals(stationID);
            //Assert.IsTrue(arrivals.Count > 0);
            //Assert.AreEqual("940GZZLUGPS", arrivals[0].naptanId);
        }

    }
}