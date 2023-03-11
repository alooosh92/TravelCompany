namespace TravelCompany.Repository
{
    public class RepSeates : IRepositorySeates
    {
        ApplicationDBContext db;

        public RepSeates(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(Seates item)
        {
            try
            {
                db.Seates?.Add(item);
            }
            catch { throw; }
        }

        public void Delete(Seates item)
        {
            try
            {
                db.Seates?.Remove(item);
            }
            catch { throw; }
        }

        public async Task<Seates>? Get(string id)
        {
            return await db.Seates?
                .Include(b => b.booking!.trips!.buses!.companies)
                .Include(b => b.booking!.trips!.buses!.region)
                .Include(b => b.booking!.trips!.from)
                .Include(b => b.booking!.trips!.to)
                .Include(b => b.booking!.personInfo!.region)                
                .Where(s => s.id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Seates>>? GetAll()
        {
            return await db.Seates?
                .Include(b => b.booking!.trips!.buses!.companies)
                .Include(b => b.booking!.trips!.buses!.region)
                .Include(b => b.booking!.trips!.from)
                .Include(b => b.booking!.trips!.to)
                .Include(b => b.booking!.personInfo!.region)
               .ToListAsync();
        }

        public async Task<List<Seates>>? GetSeatesBooking(string bookingId)
        {
            return await db.Seates?
                .Include(b => b.booking!.trips!.buses!.companies)
                .Include(b => b.booking!.trips!.buses!.region)
                .Include(b => b.booking!.trips!.from)
                .Include(b => b.booking!.trips!.to)
                .Include(b => b.booking!.personInfo!.region)
                .Where(b=>b.booking!.id == bookingId)
               .ToListAsync();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Update(Seates item)
        {
            try
            {
                db.Seates?.Update(item);
            }
            catch { throw; }
        }
    }
}
