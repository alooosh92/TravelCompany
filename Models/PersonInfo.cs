namespace TravelCompany.Models
{
    public class PersonInfo
    {
        [Key]
        public string? userId { get; set; }
        [Required]
        public string? nationalNumber { get; set; }
        [Required]
        public string? firstName { get; set; }
        [Required]
        public string? lastName { get; set; }
        [Required]
        public string? fatherName { get; set; }
        [Required]
        public string? motherName { get; set; }
        [Required]
        public string? amana { get; set; }
        [Required]
        public string? kayed { get; set; }
        [Required]
        public bool? sex { get; set; }
        [Required]
        [Phone]
        public string? phone { get; set; }
        [Required]
        public DateTime? birthDay { get; set; }
        [Required]
        public Region? region { get; set; }
    }
}
