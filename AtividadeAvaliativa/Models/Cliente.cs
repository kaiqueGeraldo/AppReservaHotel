using SQLite;
using System.ComponentModel.DataAnnotations;

namespace AtividadeAvaliativa.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [SQLite.MaxLength(80)]
        public string Nome { get; set; }

        [PrimaryKey, MinLength(11), SQLite.MaxLength(11)]
        public string CPF { get; set; }

        [SQLite.MaxLength(100)]
        public string Email { get; set; }
        public DateTime Entrada { get; set; }
    }
}
