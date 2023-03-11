namespace TravelCompany.VModels
{
    public class VMTripsCompany
    {
        public string? id { get; set; }
        public string? busLine { get; set; }
        public DateTime? dateTime { get; set; }
        public string? busesNumber { get; set; }
        public bool? vip { get; set; }
        public bool? isFull { get; set; }
        public int? chairAvailable { get; set; }
        public List<VMSeat>? chairAvailableNumber { get; set; }
    }
}
