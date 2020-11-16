using System;
using Xunit;
using clientes.infra.data.Mapping;
using clientes.infra.data.Repository;

namespace clientes.test
{
    public class Clientestest
    {
        [Fact]
        public void InsertTest()
        {
            var cliente  = new Cliente();
            cliente.Id = Guid.NewGuid();
            cliente.Nome = "Renan Cerqueira";
            cliente.DataNascimento = DateTime.Parse("20/02/1988");
            cliente.Cpf = "614.421.650-22";

            var repository = new ClientesRepository();
            var result = repository.Insert(cliente);

            Assert.True(cliente.Id.Equals(result));
        }
    }
}
