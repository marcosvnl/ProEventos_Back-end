﻿namespace ProEventos.Aplication.Dtos
{
    public class RedeSocialDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; }
        public EventoDto Evento { get; set; }
        public int? PelestranteId { get; set; }
        public PalestranteDto Palestrante { get; set; }
    }
}
