using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Persistences.Interface
{
    public interface IEventoPersist
    {
        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrantes);
    }
}
