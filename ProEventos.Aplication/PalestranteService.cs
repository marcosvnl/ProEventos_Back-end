using ProEventos.Aplication.Interface;
using ProEventos.Domain;
using ProEventos.Infrastructure.Persistences.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Aplication
{
    public sealed class PalestranteService : IPalestranteService
    {
        private readonly IPalestrantePersist _palestrantePersist;
        private readonly ICrudPersist _crudPersist;

        public PalestranteService(IPalestrantePersist palestrantePersist, ICrudPersist crudPersist)
        {
            _palestrantePersist = palestrantePersist;
            _crudPersist = crudPersist;
        }
        
        public async Task<Palestrante> AddPalestrante(Palestrante palestrante)
        {
            try
            {
                _crudPersist.Add<Palestrante>(palestrante);
                if (await _crudPersist.SaveChengesAsync())
                {
                    await _palestrantePersist.GetAllPalestranteByIdAsync(palestrante.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante palestrante)
        {
            try
            {
                 var result = await _palestrantePersist.GetAllPalestranteByIdAsync(palestranteId, false);

                if (result == null) 
                    return result = null;

                palestrante.Id = palestranteId;

                if (await _crudPersist.SaveChengesAsync())
                {
                    _crudPersist.Update<Palestrante>(palestrante);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeletePalestrante(int palestranteId)
        {
            try
            {
                var result = await _palestrantePersist.GetAllPalestranteByIdAsync(palestranteId, false);
                if (result == null) 
                    throw new Exception("Palestrante não encontrado");
                _crudPersist.Delete<Palestrante>(result);
                return await _crudPersist.SaveChengesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var result = await _palestrantePersist.GetAllPalestranteByIdAsync(palestranteId, includeEventos);
                if (result == null) 
                    throw new Exception("Palestante não encontrado");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            try
            {
                var result = await _palestrantePersist.GetAllPalestrantesAsync(includeEventos);
                if (result == null) 
                    throw new Exception("Nenhum evento cadastrado");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            try
            {
                var resul = await _palestrantePersist.GetAllPalestrantesByNomeAsync(nome, includeEventos);
                if (resul == null) 
                    throw new Exception($"Não a palestrante com o nome: { nome }");
                return resul;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
