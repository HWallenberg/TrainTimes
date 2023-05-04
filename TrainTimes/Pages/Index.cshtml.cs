using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;
using TrainTimes.WebAPI;
using TrainTimes.Logic;

namespace TrainTimes.Pages
{
    public class IndexModel : PageModel
    {
        public Dictionary<string, List<StationArrival>>? allPlatformArrivals { get; set; }
        public List<string>? platformNames { get; set; }
        public string? stationName { get; set; }
        private StationArrivals _allArrivals { get; set; }

        private readonly ILogger<IndexModel> _logger;

        //HW added read property as per SonarQube Issue L16

        public ILogger<IndexModel> Logger
        {
            get
            {
                return _logger;
            }
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _allArrivals = new StationArrivals();

        }

        public async Task OnGet()
        {
            this.allPlatformArrivals = await _allArrivals.GetPlatformsArrivals("piccadilly");
            this.platformNames = allPlatformArrivals.Keys.ToList();
            this.stationName = allPlatformArrivals[platformNames[0]].First().stationName;
        }

        
    }
}