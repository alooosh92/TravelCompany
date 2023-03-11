namespace TravelCompany.Repository
{
    public class RepRegion : IRepository<Region>
    {
        readonly ApplicationDBContext db;

        public RepRegion(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(Region item)
        {
            try
            {
                db.Region?.Add(item);
            }
            catch { throw; }

        }

        public void Delete(Region item)
        {
            try
            {
                db.Region?.Remove(item);
            }
            catch { throw; }
        }

        public async Task<Region>? Get(string id)
        {
            return await db.Region!.Where(r=> r.id == id).SingleOrDefaultAsync();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task<List<Region>> GetAll()
        {
           return await db.Region?.AsNoTracking().ToListAsync()!;
        }     

        public void Update(Region item)
        {
            try
            {               
                db.Region?.Update(item);
            }
            catch { throw; }
        }

        
    }
}
