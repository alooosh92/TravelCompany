namespace TravelCompany.VModels
{
    public class VMTripsUser
    {
        public string? id { get; set; }
        public string? busLine { get; set; }
        public DateTime? dateTime { get; set; }
        public string? color { get; set; }
        public List<string>? notes { get; set; }
        public string? shortName { get; set; }
        public int? minutes { get; set; }
        public double? price { get; set; }
        public bool? vip { get; set; }
    }
}
