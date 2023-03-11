using Microsoft.AspNetCore.Http.HttpResults;

namespace TravelCompany.Repository
{
    public class RepTrips : IRepositoryTrips
    {
       readonly ApplicationDBContext db;

        public RepTrips(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(Trips item)
        {
            try
            {
                db.Trips?.Add(item);
            }
            catch { throw; }
        }

        public async Task<List<Trips>>? companyTrips(string companyId)
        {
            return await db.Trips!
                .Include(t => t.buses!.companies)
                .Include(t => t.buses!.region)
                .Include(t => t.from)
                .Include(t => t.to)
                .Where(t=>t.buses!.companies!.id == companyId && t.date >= DateTime.Now.AddDays(-1))
                .OrderBy(t=>t.date)
               .ToListAsync();
        }

        public void Delete(Trips item)
        {
            try
            {
                db.Trips?.Remove(item);
            }
            catch { throw; }
        }

        public async Task<Trips>? Get(string id)
        {
            return await db!.Trips!
                .Include(t=>t.buses!.companies)
                .Include(t=>t.buses!.region)
                .Include(t=>t.from)
                .Include(t=>t.to)                
                .Where(t=>t.id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Trips>>? GetAll()
        {
            if (db.Trips == null) return new List<Trips>();
            return await db.Trips!
                .Include(t => t.buses!.companies)
                .Include(t => t.buses!.region)
                .Include(t => t.from)
                .Include(t => t.to)
                .Where(t => t.isFull == false && t.date >= DateTime.Today)
                .OrderBy(t=>t.date)
               .ToListAsync();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Trips item)
        {
            try
            {
                db.Trips?.Update(item);
            }
            catch { throw; }
        }
        
    }
}
