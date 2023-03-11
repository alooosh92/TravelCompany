namespace TravelCompany.data
{
    public interface IRepositoryBooking:IRepository<Booking>
    {
        public Task<List<Booking>>? userBookign(string userId);
        public Task<List<Booking>>? companyBookign(string companyId);
        public Task<List<Booking>>? tripBookign(string tripId);
    }
}
