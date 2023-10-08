namespace MAUI.CardsClient.Services.Interfaces
{
    public interface IAsyncRepository<T> : IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
