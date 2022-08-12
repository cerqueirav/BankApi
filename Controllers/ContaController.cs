using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
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

        [HttpGet]
        public List<Conta> Reader()
        {
            return _bankContext.Contas.ToList();
        } 
        
        [HttpGet("{id:int}")]
        public Conta? Reader(int id)
        {
            return _bankContext.Contas.Find(id);
        }
        
        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var conta = _bankContext.Contas.Find(id);

            if (conta is not null)
            {
                _bankContext.Remove(conta);
                _bankContext.SaveChanges();
            }  
        }

        [HttpPut("{id:int}")]
        public void Update(int id, [FromBody] Conta contaAtualizada)
        {
            var contaAtual = _bankContext.Contas.Find(id);

            if (contaAtual is not null)
            {
                if (contaAtualizada.Cliente is not null)
                    contaAtual.Cliente = contaAtualizada.Cliente;

                if (!contaAtualizada.Saldo.Equals(0))
                    contaAtual.Saldo = contaAtualizada.Saldo;

                _bankContext.SaveChanges();
            }
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