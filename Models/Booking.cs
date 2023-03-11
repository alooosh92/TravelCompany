namespace TravelCompany.Models
{
    public class Booking
    {
        [Key]       
        public string? id { get; set; }
        [Required]
        public DateTime? DateTime { get; set; }
        [Required]
        public PersonInfo? personInfo { get; set; }
        [Required]
        public bool? isPay { get; set; }
        [Required]
        public bool? isCheck { get; set; }
        [Required]
        public int? numSeates { get; set; }
        [Required]
        public Trips? trips { get; set; }
        [Required]
        public string? user { get; set; }
        [Required]
        public string? noteUser { get; set; }
        public string? noteCompany { get; set; }
    }
}
