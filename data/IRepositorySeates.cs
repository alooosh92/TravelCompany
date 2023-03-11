namespace TravelCompany.data
{
    public interface IRepositorySeates:IRepository<Seates>
    {
        public Task<List<Seates>>? GetSeatesBooking(string bookingId);
    }
}
