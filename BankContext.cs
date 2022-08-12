using BankApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApi
{
    public class BankContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }

        public BankContext(DbContextOptions<BankContext> options)
         : base(options) { }
    }
}
