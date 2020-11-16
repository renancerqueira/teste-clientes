using System;
using System.Collections.Generic;
using AutoMapper;
using clientes.domain.Model;
using clientes.infra.data.Mapping;
using clientes.infra.data.Repository;

namespace clientes.service
{
    public class BaseService<TRepository>
    {
        protected IMapper Mapper;
        protected readonly IRepository<IEntity> repository;

        public BaseService()
        {
            repository = (IRepository<IEntity>)(TRepository)Activator.CreateInstance(typeof(TRepository));
        }

        public T Get<T>(int page = 1, int length = 10)
            where T : IList<IModel>
        {
            var list = repository.Get(page, length);
            return Mapper.Map<T>(list);
        }

        public T Get<T>(Guid id)
            where T : IModel
        {
            var entry = repository.Get(id);

            return Mapper.Map<T>(entry);
        }

        public bool Any(Guid id)
        {
            return true;
        }

        public Guid Insert(IModel model)
        {
            var entry = Mapper.Map<IEntity>(model);

            return repository.Insert(entry);
        }

        public void Update(IModel model)
        {
            var entry = Mapper.Map<IEntity>(model);

            repository.Update(entry);
        }

        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
