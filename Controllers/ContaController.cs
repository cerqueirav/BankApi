using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi
{

    [ApiController]
    [Route("[controller]")]
    public class ContaController
    {
        static List<Conta> listaContas = new List<Conta>();
        static int Id = 1;

        [HttpPost]
        public void Create([FromBody] Conta conta)
        {
            conta.Id = Id++;
            listaContas.Add(conta);
        }

        [HttpGet]
        public List<Conta> Reader()
        {
            return listaContas;
        }

        [HttpGet ("{id:int}")]
        public Conta Reader(int id)
        {
            return listaContas.FirstOrDefault(conta => conta.Id == id);
        }

        [HttpPut("{id:int}")]
        public void Update(int id, Conta novaConta)
        {
            var conta = listaContas.FirstOrDefault(conta => conta.Id == id);

            conta.Cliente = novaConta.Cliente;
            conta.Saldo = novaConta.Saldo;
            
        }


        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            Conta conta = listaContas.FirstOrDefault(conta => conta.Id == id);

            listaContas.Remove(conta);
        }

    }
}