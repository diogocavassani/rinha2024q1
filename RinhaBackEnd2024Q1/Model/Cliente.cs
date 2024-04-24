using RinhaBackEnd2024Q1.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RinhaBackEnd2024Q1.Model
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            Transacoes = new List<Transacao>();
        }
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Limite")]
        [Required]
        public int Limite { get; set; }
        
        [Column("Saldo")]
        [Required]
        public int Saldo { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }

        public bool AddTransacao(TransacaoViewModel transacao)
        {
            if(transacao.Tipo == 'c')
                Saldo += transacao.Valor;
            else if(transacao.Tipo == 'd'){
                Saldo -= transacao.Valor;
                if (Saldo < Limite)
                    return false;
            }
           

            Transacoes.Add(new Transacao { Descricao = transacao.Descricao, Tipo = transacao.Tipo, valor = transacao.Valor, Realizada_em = DateTime.Now, Cliente = this });
            return true;
        }
    }
}

