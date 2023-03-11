namespace TravelCompany.Models
{
    public class NotesCompany
    {
        [Key]
        public string? id { get; set; }
        [Required]
        public Companies? companies { get; set; }
        [Required]
        public string? note { get; set; }
    }
}
