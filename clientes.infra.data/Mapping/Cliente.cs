using System;

namespace clientes.infra.data.Mapping
{
    public class Cliente : IEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime CadastradoEm { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
    }
}
