using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RinhaBackEnd2024Q1.Model
{
    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        
        [Column("valor")]
        [Required]
        public int valor { get; set; }
        
        [Column("tipo")]
        [Required]
        public char Tipo { get; set; }
        
        [Column("descricao")]
        [Required]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string Descricao { get; set; }
        
        [Column("realizada_em")]
        [Required]
        public DateTime Realizada_em { get; set; }
        public Cliente Cliente { get; set; }
        [JsonIgnore]
        public int IdCliente { get; set; }
    }
}

