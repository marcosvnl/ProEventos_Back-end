using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Infrastructure.Data;
using ProEventos.Infrastructure.Persistences.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Persistences
{
    public sealed class PalestrantePersist : IPalestrantePersist
    {
        private readonly DataContext _dataContext;

        public PalestrantePersist(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _dataContext.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _dataContext.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _dataContext.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(ep => ep.Evento);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}
