using ProEventos.Infrastructure.Data;
using ProEventos.Infrastructure.Persistences.Interface;
using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Persistences
{
    public sealed class CrudPersist : ICrudPersist
    {
        private readonly DataContext _dataContext;

        public CrudPersist(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public void DeleteRange<T>(T entity) where T : class
        {
            _dataContext.RemoveRange(entity);
        }
        public async Task<bool> SaveChengesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }
    }
}
