namespace TravelCompany.data
{
    public interface IRepositoryNotes:IRepository<NotesCompany>
    {
        public Task<List<NotesCompany>>? getCompanyNotes(string id);
    }
}
