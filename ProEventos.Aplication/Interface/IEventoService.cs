using ProEventos.Aplication.Dtos;
using System.Threading.Tasks;

namespace ProEventos.Aplication.Interface
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(EventoDto evento);
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto evento);
        Task<bool> DeleteEvento(int eventoId);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<EventoDto> GetAllEventoByIdAsync(int EventoId, bool includePalestrantes = false);
    }
}
