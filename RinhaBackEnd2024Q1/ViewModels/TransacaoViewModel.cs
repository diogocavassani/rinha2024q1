using System.ComponentModel.DataAnnotations;

namespace RinhaBackEnd2024Q1.ViewModels
{
    public class TransacaoViewModel
    {
        [Required]
        public int Valor { get; set; }
        [Required]
        public char Tipo { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string Descricao { get; set; }
    }
}
