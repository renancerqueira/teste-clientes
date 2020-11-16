using System;
using System.Collections.Generic;
using AutoMapper;
using clientes.domain.Model;
using clientes.infra.data.Mapping;
using clientes.infra.data.Repository;

namespace clientes.service
{
    public class ClientesService : BaseService<ClientesRepository>
    {
        public ClientesService(IMapper mapper)
        {
            this.Mapper = mapper;
        }
        public IList<ClienteModel> Get(int page = 1, int length = 10, string containsName = "")
        {
            var list = repository.Get(page, length, $"Nome like '%{containsName}%'");
            return Mapper.Map<IList<ClienteModel>>(list);
        }
        public Guid Insert(ClienteModel model)
        {
            var entry = Mapper.Map<Cliente>(model);
            entry.Id = new Guid();

            repository.Insert(entry);

            return entry.Id;
        }
    }
}
