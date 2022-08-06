using System.Text.Json.Serialization;

namespace BankApi.Models
{
    public class Conta
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        public double Saldo { get; set; }   
    }
}