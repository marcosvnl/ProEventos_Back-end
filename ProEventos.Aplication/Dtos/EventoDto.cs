using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Aplication.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [
            Required(ErrorMessage = "O campo {0} é obrigatório"),
            StringLength(49, MinimumLength = 3, ErrorMessage = "O Campo {0} deve conter entre 4 e 50 caracteres")
        ]
        public string Tema { get; set; }
        [
            Display(Name = "Qtd Pessoas"),
            Range(3, 5000, ErrorMessage = "Campo {0} , deve conter um valor de 3 à 5.000")
        ]
        public int QtdPessoas { get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. Ex: (.gif, .jpg, jpeg, bmp e .png)")]
        public string ImagemUrl { get; set; }
        [
            Required(ErrorMessage = "O campo {0} é obrigatório"),
            Phone(ErrorMessage = "Deve conter um {0} válido")
        ]
        public string Telefone { get; set; }
        [
            Display(Name ="E-mail"),
            EmailAddress(ErrorMessage = " O Campo {0}, não é um endereço válido"),
            Required(ErrorMessage = "O {0} é um campo obrigatório")
        ]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lote { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes{ get; set; }
    }
}
