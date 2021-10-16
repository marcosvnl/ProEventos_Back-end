using AutoMapper;
using ProEventos.Aplication.Dtos;
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
        private  readonly IMapper _autoMapper;

        public EventoService(IMapper autoMapper, ICrudPersist crudPersist, IEventoPersist eventoPersist)
        {
            _crudPersist = crudPersist;
            _eventoPersist = eventoPersist;
            _autoMapper = autoMapper;
        }
        
        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                Evento evento = _autoMapper.Map<Evento>(model);
                _crudPersist.Add<Evento>(evento);

                if (await _crudPersist.SaveChengesAsync())
                {
                    Evento eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(evento.Id, false);
                    return _autoMapper.Map<EventoDto>(eventoRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventoByIdAsync(eventoId, false);

                if(result == null) return null;

                model.Id = eventoId;

                _autoMapper.Map(model, result);

                _crudPersist.Update<Evento>(result);

                if (await _crudPersist.SaveChengesAsync())
                {
                    Evento eventoRetorno = await _eventoPersist.GetAllEventoByIdAsync(model.Id, false);
                    return _autoMapper.Map<EventoDto>(eventoRetorno);
                }

                return null;
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

        public async Task<EventoDto> GetAllEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventoByIdAsync(eventoId, includePalestrantes);
                if (result == null) 
                    throw new Exception($"Não foi encontrado eventos contendo o N°: {eventoId}");

                EventoDto eventoRetorno =  _autoMapper.Map<EventoDto>(result);

                return eventoRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (result == null)  throw new Exception("Eventos não encontrado.");

                EventoDto[] eventoRetorno = _autoMapper.Map<EventoDto[]>(result);

                return eventoRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var result = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (result == null) 
                    throw new Exception($"Não foi encontrado eventos contendo o tema: {tema}");

                EventoDto[] eventoRetorno = _autoMapper.Map<EventoDto[]>(result);

                return eventoRetorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
