using RinhaBackEnd2024Q1.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RinhaBackEnd2024Q1.Model
{
    [Table("cliente")]
    public class Cliente
    {
        public Cliente()
        {
            Transacoes = new List<Transacao>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("limite")]
        [Required]
        public int Limite { get; set; }
        
        [Column("saldo")]
        [Required]
        public int Saldo { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }

        public bool AddTransacao(TransacaoViewModel transacao)
        {
            Saldo -= transacao.Valor;
            if (Saldo > Limite * -1)
                return false;

            Transacoes.Add(new Transacao { Descricao = transacao.Descricao, Tipo = transacao.Tipo, valor = transacao.Valor, Realizada_em = DateTime.Now, Cliente = this, IdCliente = this.Id });
            return true;
        }
    }
}

