namespace TravelCompany.Models
{
    public class Trips
    {
        [Key]
        public string? id { get; set; }
        [Required]
        public Buses? buses { get; set; }
        [Required]
        public DateTime? date { get; set; }
        [Required]
        public int? minutes { get; set; }
        [Required]
        public double? price { get; set; }
        [Required]
        public Region? from { get; set; }
        [Required]
        public Region? to { get; set; }
        [Required]
        public bool? isFull { get; set; }
    }
}
