namespace TravelCompany.VModels
{
    public class VMBookingCompany
    {
        public string? id { get; set; }
        public string? busLine { get; set; }
        public DateTime? dateTimeBooking { get; set; }
        public DateTime? dateTimeTravel { get; set; }
        public int? seateNumber { get; set; }
        public List<int?>? seates { get; set; }
        public bool? isPay { get; set; }
        public bool? isCheck { get; set; }
        public string? busNumber { get; set; }
    }
}
