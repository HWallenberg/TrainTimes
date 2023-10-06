using TrainTimes.WebAPI;
namespace TrainTimes.Logic
{
    public class Platform
    {
        public string? name { get; set; }
        public string? number { get; set; }
        public List<StationArrival>? arrivals { get; set; }

    }
}
