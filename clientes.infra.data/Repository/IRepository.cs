using System;
using System.Collections.Generic;
using clientes.infra.data.Mapping;

namespace clientes.infra.data.Repository
{
    public interface IRepository<T>
        where T : IEntity
    {
        Guid Insert(T entry);
        void Update(T entry);
        void Delete(Guid id);
        T Get(Guid id);
        IEnumerable<T> Get(int page, int length);
        IEnumerable<T> Get(int page, int length, string conditions);
    }
}
