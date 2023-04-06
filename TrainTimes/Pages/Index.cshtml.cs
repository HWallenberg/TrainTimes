using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;
using TrainTimes.WebAPI;
using TrainTimes.Logic;

namespace TrainTimes.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, List<StationArrival>> platformsArrivals { get; set; }
        public List<string> platformNames { get; set; }
        public string stationName { get; set; }
        private NextTrains _nextTrains { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _nextTrains = new NextTrains();

        }

        public async Task OnGet()
        {
            this.platformsArrivals = await _nextTrains.GetPlatformsArrivals();
            this.platformNames = platformsArrivals.Keys.ToList();
            this.stationName = platformsArrivals[platformNames[0]].First().stationName;
        }

        
    }
}