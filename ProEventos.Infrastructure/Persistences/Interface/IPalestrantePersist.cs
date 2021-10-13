using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Infrastructure.Persistences.Interface
{
    public interface IPalestrantePersist
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}
