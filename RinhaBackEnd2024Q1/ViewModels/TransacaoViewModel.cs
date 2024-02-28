using System.ComponentModel.DataAnnotations;

namespace RinhaBackEnd2024Q1.ViewModels
{
    public class TransacaoViewModel
    {
        public int Valor { get; set; }
        public char Tipo { get; set; }
        public string Descricao { get; set; }
        public bool isValid()
        {
            return Valor > 0
                && !string.IsNullOrEmpty(Descricao)
                && Descricao.Length <= 10 && Descricao.Length >= 1
                && (Tipo == 'd' || Tipo == 'c');
        }
    }
}
