namespace DataAcessLayer.Interfaces
{
    internal interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);


    }
}
