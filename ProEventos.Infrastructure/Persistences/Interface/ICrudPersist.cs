using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Persistences.Interface
{
    public interface ICrudPersist
    {
        //CRUD
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T entity) where T : class;
        Task<bool> SaveChengesAsync();
    }
}
