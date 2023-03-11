namespace TravelCompany.Models
{
    public class Buses
    {
        [Key]
        public string? id { get; set; }
        [Required]
        public string? busNumber { get; set;}
        [Required]
        public string? paletNumber { get; set; }
        [Required]
        public Region? region{get; set; }
        [Required]
        public int? seatsNumber { get; set; }
        [Required]
        public bool? active { get; set; }
        [Required]
        public bool? vip { get; set; }
        [Required]
        public Companies? companies { get; set; }
    }
}
