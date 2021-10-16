using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Aplication.Dtos;
using ProEventos.Aplication.Interface;
using System;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()     
        {
            try
            {
                var result = await _eventoService.GetAllEventosAsync(true);
                if (result == null) return NoContent();
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Error: { ex.Message }");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _eventoService.GetAllEventoByIdAsync(id, true);
                if (result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento. Error: { ex.Message }");
            }
        }

        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var result = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar evento apartir do tema. Error: { ex.Message }");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventoDto evento)
        {
            try
            {
                var result = await _eventoService.AddEvento(evento);
                if (result == null) return NoContent();
                return CreatedAtAction("GetById", new { Id = evento.Id });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar um evento. Error: { ex.Message }");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventoDto evento)
        {            
            try
            {
                var result = await _eventoService.UpdateEvento(id, evento);
                if (result == null) return NoContent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar alterar um evento. Error: { ex.Message }");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _eventoService.GetAllEventosAsync(true);
                if (result == null) return NoContent();

                return await _eventoService.DeleteEvento(id) ? Ok("Evento deletado.") : BadRequest("Evento não encontrado");        
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar um evento. Error: { ex.Message }");
            }
        }
    }
}
