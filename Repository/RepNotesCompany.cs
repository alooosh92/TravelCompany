namespace TravelCompany.Repository
{
    public class RepNotesCompany : IRepositoryNotes
    {
        ApplicationDBContext db;

        public RepNotesCompany(ApplicationDBContext db)
        {
            this.db = db;
        }

        public void Add(NotesCompany item)
        {
            try
            {
                db.NotesCompany?.Add(item);
            }
            catch { throw; }
        }

        public void Delete(NotesCompany item)
        {
            try
            {
                db.NotesCompany?.Remove(item);
            }
            catch { throw; }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task<NotesCompany>? Get(string id)
        {
            return await db.NotesCompany?
                .Include(n=>n.companies)
                .Where(n => n.id == id).SingleOrDefaultAsync();
        }

        public async Task<List<NotesCompany>>? GetAll()
        {
            return await db.NotesCompany?
                .Include(n => n.companies)
               .ToListAsync();
        }

        public async Task<List<NotesCompany>>? getCompanyNotes(string id)
        {
            return await db.NotesCompany?
                .Include(n => n.companies)
                .Where(n=>n.companies.id == id)
               .ToListAsync();
        }

        public void Update(NotesCompany item)
        {
            try
            {
                db.NotesCompany?.Update(item);
            }
            catch { throw; }
        }
    }
}
