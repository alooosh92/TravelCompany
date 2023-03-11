namespace TravelCompany.VModels
{
    public class VMBookingPostCompany
    {
        public string? note { get; set; }
        public string? userId { get; set; }
        public int? numSeate { get; set; }
        public string? tripId { get; set; }
        public string? personId { get; set; }
        public List<int>? seates {get;set; }
        public bool? isPay { get; set; }
    }
}
