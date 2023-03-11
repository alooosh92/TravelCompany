namespace TravelCompany.data
{
    public interface IRepositoryTrips:IRepository<Trips>
    {
        public Task<List<Trips>>? companyTrips(string companyId);
    }
}
