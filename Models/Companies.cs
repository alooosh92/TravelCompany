namespace TravelCompany.Models
{
    public class Companies
    {
        [Key]
        public string? id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? shortName { get; set; }
        [Required]
        [Phone]
        public string? phone { get; set; }
        [Required]
        public bool? active { get; set; }
        [Required]
        public string? color { get; set; }
    }
}
