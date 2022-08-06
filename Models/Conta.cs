using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BankApi.Models
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }
        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
        public double Saldo { get; set; }
       
    }
}