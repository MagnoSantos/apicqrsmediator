using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Models;

namespace webapicqrsmediator.Domain.Repositories
{
    public interface IBaseClienteRepository<TEntity> where TEntity : Base
    {
        Task Adicionar(TEntity entidade);

        Task Atualizar(TEntity entidade);

        Task<TEntity> ObterPorId(Guid id);

        Task<List<TEntity>> Obter();
    }
}