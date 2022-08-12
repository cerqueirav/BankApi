
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController
    {
        private readonly BankContext _bankContext;
        
        public ClienteController(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        [HttpPost]
        public void Create([FromBody] Cliente cliente)
        {
            _bankContext.Clientes.Add(cliente);
            _bankContext.SaveChanges();
        }

        [HttpGet]
        public List<Cliente> Reader()
        {
            return _bankContext.Clientes.ToList();
        }

        [HttpGet("{id:int}")]
        public Cliente? Reader(int id)
        {
            return _bankContext.Clientes.Find(id);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var cliente = _bankContext.Clientes.Find(id);

            if (cliente is not null)
            {
                _bankContext.Clientes.Remove(cliente);
                _bankContext.SaveChanges();
            }
        }

        [HttpPut("{id:int}")]
        public void Update(int id, [FromBody] Cliente clienteAualizado)
        {
            var clienteAtual = _bankContext.Clientes.Find(id);

            if (clienteAtual is not null)
            {
                //if (!clienteAualizado.ClienteId.Equals(0))
                //    clienteAtual.ClienteId = clienteAualizado.ClienteId;

                if (!String.IsNullOrEmpty(clienteAualizado.Nome))
                    clienteAtual.Nome = clienteAualizado.Nome;

                if (!String.IsNullOrEmpty(clienteAualizado.Cpf))
                    clienteAtual.Cpf = clienteAualizado.Cpf;

                _bankContext.SaveChanges();
            }
        }

        //[HttpPost]
        //public void Create([FromBody] Cliente cliente)
        //{
        //    cliente.ClienteId = Id++;
        //    listaClientes.Add(cliente);
        //}

        //[HttpGet]
        //public List<Cliente> Reader()
        //{
        //    return listaClientes;
        //}

        //[HttpGet("{id:int}")]
        //public Cliente Reader(int id) 
        //{
        //    return listaClientes.FirstOrDefault(cliente => cliente.ClienteId.Equals(id));
        //}

        //[HttpPut("{id:int}")]
        //public void Update(int id, [FromBody] Cliente novoCliente)
        //{
        //    var cliente = listaClientes.FirstOrDefault(cliente => cliente.ClienteId.Equals(id));

        //    cliente.Nome = novoCliente.Nome;
        //    cliente.Cpf = novoCliente.Cpf;
        //}

        //[HttpDelete("{id:int}")]
        //public void Delete(int id)
        //{
        //    var cliente = listaClientes.FirstOrDefault(cliente => cliente.ClienteId.Equals(id));

        //    if(cliente is not null)
        //        listaClientes.Remove(cliente);
        //}
    }
}
