namespace Domain_DataBase.Domain_Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetAll();
    }
}
