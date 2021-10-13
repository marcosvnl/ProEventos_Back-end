using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplication.Interface
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrante(Palestrante  palestrante);
        Task<Palestrante> UpdatePalestrante(int palestranteId,Palestrante palestrante);
        Task<bool> DeletePalestrante(int palestranteId);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}
