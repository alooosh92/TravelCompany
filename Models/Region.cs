namespace TravelCompany.Models
{
    public class Region
    {
        [Key]
        public string? id { get; set; }
        [Required]
        public string? enRegion { get; set; }
        [Required]
        public string? arRegion { get; set; }
    }
}
