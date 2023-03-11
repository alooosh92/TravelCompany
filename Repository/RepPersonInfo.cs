namespace TravelCompany.Repository
{
    public class RepPersonInfo : IRepository<PersonInfo>
    {
        ApplicationDBContext db;

        public RepPersonInfo(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(PersonInfo item)
        {
            try
            {
                db.PersonInfo?.Add(item);
            }
            catch { throw; }
        }

        public void Delete(PersonInfo item)
        {
            try
            {
                db.PersonInfo?.Remove(item);
            }
            catch { throw; }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task<PersonInfo>? Get(string id)
        {
            return await db.PersonInfo
                .Include(p => p.region)
                .Where(p => p.userId == id).SingleOrDefaultAsync()!;
        }

        public async Task<List<PersonInfo>>? GetAll()
        {
            return await db.PersonInfo?
                .Include(p => p.region)
                .ToListAsync();
        }

        public void Update(PersonInfo item)
        {
            try
            {
                db.PersonInfo?.Update(item);
            }
            catch { throw; }
        }
    }
}
