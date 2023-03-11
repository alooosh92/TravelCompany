namespace TravelCompany.data
{
    public interface IRepositoryBuses:IRepository<Buses>
    {
        public Task<List<Buses>>? GetBusesCompany(string id);
    }
}
