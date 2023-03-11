namespace TravelCompany.data
{
    public class AuthModel
    {
        public string? Message { get; set; }
        public bool IsAuthanticated { get; set; }
        public string? Username { get; set; }
        public IList<string>? Roles { get; set; }
        public string? Token { get; set; }
        public DateTime? Expireson { get; set; }
    }
}
