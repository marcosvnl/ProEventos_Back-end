using ProEventos.Aplication.Interface;
using ProEventos.Domain;
using ProEventos.Infrastructure.Persistences.Interface;
using System;
using System.Threading.Tasks;

namespace ProEventos.Aplication
{
    public sealed class EventoService : IEventoService
    {
        private readonly ICrudPersist _crudPersist;
        private readonly IEventoPersist _eventoPersist;

        public EventoService(ICrudPersist crudPersist, IEventoPersist eventoPersist)
        {
            _crudPersist = crudPersist;
            _eventoPersist = eventoPersist;
        }
        
        public async Task<Evento> AddEvento(Evento evento)
        {
            try
            {
                _crudPersist.Add<Evento>(evento);

                if (await _crudPersist.SaveChengesAsync())
                {
                    return await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento evento)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);

                if(result == null) return null;

                result.Id = eventoId;

                _crudPersist.Update(evento);

                if (await _crudPersist.SaveChengesAsync())
                {
                    return await _eventoPersist.GetAllEventoByIdAsync(result.Id, false);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);
                if (result == null) 
                    throw new Exception("Evento não encontrado.");
                _crudPersist.Delete<Evento>(result);
                return await _crudPersist.SaveChengesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventoByIdAsync(eventoId, includePalestrantes);
                if (result == null) 
                    throw new Exception($"Não foi encontrado eventos contendo o N°: {eventoId}");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (result == null) 
                    throw new Exception("Eventos não encontrado.");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (result == null) 
                    throw new Exception($"Não foi encontrado eventos contendo o tema: {tema}");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
