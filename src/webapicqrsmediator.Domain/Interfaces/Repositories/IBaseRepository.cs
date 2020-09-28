using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Entities;

namespace webapicqrsmediator.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : Base
    {
        Task Adicionar(TEntity entidade);

        Task Atualizar(TEntity entidade);

        Task<TEntity> ObterPorId(Guid id);

        Task<List<TEntity>> Obter();
    }
}