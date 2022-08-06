using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi
{

    [ApiController]
    [Route("[controller]")]
    public class ContaController
    {
        private readonly BankContext _bankContext;

        public ContaController(BankContext bankContext)
        {
            _bankContext = bankContext; 
        }

        [HttpPost]
        public void Create([FromBody] Conta conta)
        {

            _bankContext.Contas.Add(conta);
            _bankContext.SaveChanges();
        }

        //[HttpGet]
        //public List<Conta> Reader()
        //{
        //    return listaContas;
        //}

        //[HttpGet ("{id:int}")]
        //public Conta Reader(int id)
        //{
        //    return listaContas.FirstOrDefault(conta => conta.ContaId == id);
        //}

        //[HttpPut("{id:int}")]
        //public void Update(int id, Conta novaConta)
        //{
        //    var conta = listaContas.FirstOrDefault(conta => conta.ContaId == id);

        //    conta.Cliente = novaConta.Cliente;
        //    conta.Saldo = novaConta.Saldo;
            
        //}


        //[HttpDelete("{id:int}")]
        //public void Delete(int id)
        //{
        //    Conta conta = listaContas.FirstOrDefault(conta => conta.ContaId == id);

        //    listaContas.Remove(conta);
        //}

    }
}