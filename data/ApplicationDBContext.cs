namespace TravelCompany.data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Booking>? Booking { get; set; }
        public DbSet<Buses>? Buses { get; set; }
        public DbSet<Companies>? Companies { get; set; }
        public DbSet<NotesCompany>? NotesCompany { get; set; }
        public DbSet<PersonInfo>? PersonInfo { get; set; }
        public DbSet<Region>? Region { get; set; }
        public DbSet<Seates>? Seates { get; set; }
        public DbSet<Trips>? Trips { get; set; }
    }
}
