using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Infrastructure.Data;
using ProEventos.Infrastructure.Persistences.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Persistences
{
    public sealed class EventoPersist : IEventoPersist
    {
        private readonly DataContext _dataContext;
        public EventoPersist(DataContext dataContext)
        {
            _dataContext = dataContext;
            //não deixar os eventos do EventoPersist Trackeados
            //_dataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _dataContext.Eventos
                .Include(e => e.RedesSociais)
                .Include(e => e.Lote);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                IQueryable<Evento> query = _dataContext.Eventos
                .Include(e => e.Lote)
                .Include(e => e.RedesSociais);

                if (includePalestrantes)
                {
                    query = query
                        .Include(e => e.PalestrantesEventos)
                        .ThenInclude(pe => pe.Palestrante);
                }

                query = query.AsNoTracking().OrderBy(e => e.Id); //AsNoTracking() ==> não deixa o evento em Tracking

                return await query.ToArrayAsync();
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _dataContext.Eventos
                .Include(e => e.RedesSociais)
                .Include(e => e.Lote);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
