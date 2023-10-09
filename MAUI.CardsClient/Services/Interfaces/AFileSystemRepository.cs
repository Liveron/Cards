using MAUI.CardsClient.Models;

namespace MAUI.CardsClient.Services.Interfaces
{
    public abstract class AFileSystemRepository<T> : IAsyncRepository<T>, IRepository<T>, IDisposable, IAsyncDisposable where T : class
    {
        private bool disposedValue;

        public abstract void Create(T entity);
        public abstract Task CreateAsync(T entity);
        public abstract void Delete(int id);
        public abstract T Get(int id);
        public abstract IEnumerable<T> GetAll();
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public abstract void Update(T entity);
        protected abstract void Disposing();
        protected abstract ValueTask DisposingAsync();

        protected void Dispose(bool disposing)
        {
            if (disposedValue) return;     
            
            if (disposing) Disposing();

            disposedValue = true;     
        }

        protected async ValueTask DisposeAsync(bool disposing)
        {
            if (disposedValue) return;

            if (disposing) await DisposingAsync();

            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        ~AFileSystemRepository()
        {
            Dispose(disposing: false);
        }
    }
}
