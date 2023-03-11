namespace TravelCompany.VModels
{
    public class VMCompany
    {
        public string? name { get; set; }
        public string? shortName { get; set; }
        public string? phone { get; set; }
        public bool? active { get; set; }
        public string? color { get; set; }
        public List<string>? notes { get; set; }
    }
}
