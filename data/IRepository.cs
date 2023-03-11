namespace TravelCompany.data
{
    public interface IRepository<T>
    {
        public Task<List<T>>? GetAll();
        public Task<T>? Get(string id);
        public void Add(T item);
        public void Update(T item);
        public void Delete(T item);
        public void Save();
    }
}
