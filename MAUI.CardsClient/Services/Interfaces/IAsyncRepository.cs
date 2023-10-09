namespace MAUI.CardsClient.Services.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
