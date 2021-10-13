using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplication.Interface
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento evento);
        Task<Evento> UpdateEvento(int eventoId, Evento evento);
        Task<bool> DeleteEvento(int eventoId);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrantes = false);
    }
}
