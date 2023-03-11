namespace TravelCompany.Repository
{
    public class RepCompany : IRepository<Companies>
    {
        ApplicationDBContext db;

        public RepCompany(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(Companies item)
        {
            try
            {
                db.Companies?.Add(item);                
            }
            catch { throw; }
        }

        public void Delete(Companies item)
        {
            try
            {
                db.Companies?.Remove(item);
            }
            catch { throw; }
        }

        public async Task<Companies>? Get(string id)
        {
            return await db.Companies?.Where(c => c.id == id).SingleOrDefaultAsync();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task< List<Companies>>? GetAll()
        {
            return await db.Companies?.ToListAsync();
        }

        public void Update(Companies item)
        {
            try
            {
                db.Companies?.Update(item);
            }
            catch { throw; }
        }
    }
}
