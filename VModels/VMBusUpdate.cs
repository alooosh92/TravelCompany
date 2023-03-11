namespace TravelCompany.VModels
{
    public class VMBusUpdate
    {
        public string? busNumber { get; set; }        
        public string? paletNumber { get; set; }        
        public string? region { get; set; }
        public int? seatsNumber { get; set; }
        public bool? active { get; set; }
        public bool? vip { get; set; }
    }
}
