namespace TravelCompany.Repository
{
    public class RepBooking : IRepositoryBooking
    {
        ApplicationDBContext db;

        public RepBooking(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(Booking item)
        {
            try
            {
                db.Booking?.Add(item);
            }catch
            { throw; }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task<List<Booking>>? companyBookign(string companyId)
        {
            return await db.Booking!
                .Include(b=>b.trips!.buses!.companies)
                .Include(b=>b.trips!.buses!.region)
                .Include(b=>b.trips!.from)
                .Include(b=>b.trips!.to)
                .Include(b=>b.personInfo!.region)
                .Where(b => b.trips!.buses!.companies!.id == companyId && b.trips.date >= DateTime.Today).ToListAsync();
        }

        public void Delete(Booking item)
        {
            try
            {
                db.Booking?.Remove(item);
            }
            catch
            { throw; }
        }

        public async Task<Booking>? Get(string id)
        {
            return await db.Booking!
                .Include(b => b.trips!.buses!.companies)
                .Include(b => b.trips!.buses!.region)
                .Include(b => b.trips!.from)
                .Include(b => b.trips!.to)
                .Include(b => b.personInfo!.region)
                .Where(b => b.id == id)!.SingleOrDefaultAsync()!;
        }

        public async Task<List<Booking>>? GetAll()
        {
            return await db.Booking!
                .Include(b => b.trips!.buses!.companies)
                .Include(b => b.trips!.buses!.region)
                .Include(b => b.trips!.from)
                .Include(b => b.trips!.to)
                .Include(b => b.personInfo!.region)
                .ToListAsync();
        }

        public async Task<List<Booking>>? tripBookign(string tripId)
        {
            return await db.Booking!
                .Include(b => b.trips!.buses!.companies)
                .Include(b => b.trips!.buses!.region)
                .Include(b => b.trips!.from)
                .Include(b => b.trips!.to)
                .Include(b => b.personInfo!.region)
                .Where(b=>b.trips!.id == tripId)
                .ToListAsync()!;
        }

        public void Update(Booking item)
        {
            try
            {
                db.Booking?.Update(item);
            }
            catch
            { throw; }
        }

        public async Task<List<Booking>>? userBookign(string userId)
        {
            return await db.Booking!
                .Include(b => b.trips!.buses!.companies)
                .Include(b => b.trips!.buses!.region)
                .Include(b => b.trips!.from)
                .Include(b => b.trips!.to)
                .Include(b => b.personInfo!.region)
                .Where(b => b.user == userId)
                .OrderByDescending(t=>t.DateTime)
                .ToListAsync();
        }

    }
}
