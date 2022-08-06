using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string? Cpf { get; set; }
      
    }
}
