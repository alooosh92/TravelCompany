namespace TravelCompany.VModels
{
    public class VMBookingUser
    {
        public string? id { get; set; }
        public DateTime? dateTimeBooking { get; set; }
        public DateTime? dateTimeTravel { get; set; }
        public string? color { get; set; }
        public string? shortName { get; set; }
        public int? seateNumber { get; set; }
        public List<int?>? seates { get; set; }
        public bool? isPay { get; set; }
        public bool? isCheck { get; set; }
        public string? busNumber { get; set; }
        public string? from { get; set; }
        public string? to { get; set; }
        public double? price { get; set; }
        public bool? vip { get; set; }
    }
}
