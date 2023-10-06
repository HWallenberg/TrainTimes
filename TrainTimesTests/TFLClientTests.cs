using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTimes.WebAPI;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TrainTimesTests
{
    [TestClass]
    public class TFLClientTests
    {
        TflClient client { get; set; }
        public TFLClientTests()
        {
            client = new TflClient(@"https://api.tfl.gov.uk");
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
    }
}