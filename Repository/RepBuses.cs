namespace TravelCompany.Repository
{
    public class RepBuses : IRepositoryBuses
    {
        ApplicationDBContext db;

        public RepBuses(ApplicationDBContext db)
        {
            this.db = db;
        }
        public void Add(Buses item)
        {
            try
            {
                db.Buses?.Add(item);
            }
            catch
            { throw; }
        }

        public void Delete(Buses item)
        {
            try
            {
                db.Buses?.Remove(item);
            }
            catch
            { throw; }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task<Buses>? Get(string id)
        {
            return await db.Buses?
                .Include(b=>b.companies)
                .Include(b=>b.region)
                .Where(b=> b.id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Buses>>? GetAll()
        {
            return await db.Buses?
                .Include(b => b.companies)
                .Include(b => b.region)
                .ToListAsync();
        }

        public async Task<List<Buses>>? GetBusesCompany(string id)
        {
            return await db.Buses?
               .Include(b => b.companies!)
               .Include(b => b.region!)
               .Where(b=>b.companies!.id == id)
               .ToListAsync();
        }

        public void Update(Buses item)
        {
            try
            {
                db.Buses?.Update(item);
            }
            catch
            { throw; }
        }
    }
}
