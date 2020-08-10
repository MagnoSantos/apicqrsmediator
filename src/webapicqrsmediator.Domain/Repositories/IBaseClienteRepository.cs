using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Entities;

namespace webapicqrsmediator.Domain.Repositories
{
    public interface IBaseClienteRepository<TEntity> where TEntity : EntityBase
    {
        Task Adicionar(TEntity entidade);

        Task Atualizar(TEntity entidade);

        Task<TEntity> ObterPorId(Guid id);

        Task<List<TEntity>> Obter();
    }
}