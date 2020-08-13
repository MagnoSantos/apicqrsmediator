using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Models;
using webapicqrsmediator.Domain.Repositories;
using webapicqrsmediator.Infrastructure.Data.Context;

namespace webapicqrsmediator.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Adicionar(Cliente entidade)
        {
            _dataContext.Add(entidade);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Atualizar(Cliente entidade)
        {
            _dataContext.Entry(entidade).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public Task<List<Cliente>> Obter()
        {
            return _dataContext.Clientes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _dataContext.Clientes
                .FindAsync(id);
        }
    }
}