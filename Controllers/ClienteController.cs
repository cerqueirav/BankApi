using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController
    {
        static List<Cliente> listaClientes = new List<Cliente>();

        static int Id = 1;

        [HttpPost]
        public void Create([FromBody] Cliente cliente)
        {
            cliente.ClienteId = Id++;
            listaClientes.Add(cliente);
        }

        [HttpGet]
        public List<Cliente> Reader()
        {
            return listaClientes;
        }

        [HttpGet("{id:int}")]
        public Cliente Reader(int id) 
        {
            return listaClientes.FirstOrDefault(cliente => cliente.ClienteId.Equals(id));
        }

        [HttpPut("{id:int}")]
        public void Update(int id, [FromBody] Cliente novoCliente)
        {
            var cliente = listaClientes.FirstOrDefault(cliente => cliente.ClienteId.Equals(id));

            cliente.Nome = novoCliente.Nome;
            cliente.Cpf = novoCliente.Cpf;
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            var cliente = listaClientes.FirstOrDefault(cliente => cliente.ClienteId.Equals(id));

            if(cliente is not null)
                listaClientes.Remove(cliente);
        }


    }
}
