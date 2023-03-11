namespace TravelCompany.Models
{
    public class Seates
    {
        [Key]
        public string? id { get; set; }
        [Required]
        public Booking? booking { get; set; }
        [Required]
        public int? seatNumber { get; set; }

    }
}
