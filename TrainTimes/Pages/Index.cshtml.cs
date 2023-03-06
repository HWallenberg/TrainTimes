using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;
using TrainTimes.WebAPI;
using TrainTimes.Logic;

namespace TrainTimes.Pages
{
    public class IndexModel : PageModel
    {
        public List<StationArrival> platform1Arrivals {get; set;}
        public List<StationArrival> platform2Arrivals { get; set; }
        private NextTrains _nextTrains { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _nextTrains = new NextTrains();

        }

        public async Task OnGet()
        {
            this.platform1Arrivals = await _nextTrains.GetPortlandStreetPlatformsArrivals(4, "Westbound - Platform 1");
            this.platform2Arrivals = await _nextTrains.GetPortlandStreetPlatformsArrivals(4, "Eastbound - Platform 2");
        }

        
    }
}