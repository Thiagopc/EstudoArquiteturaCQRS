using ProjetoEstudoCQRS.domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.infra.Connection.Repositories
{
    internal class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ConnectionDb _connection;
        public RepositoryBase(ConnectionDb connection)
        {
            this._connection = connection;
        }

        public void Add(TEntity entity)
        {
            this._connection.Set<TEntity>().Add(entity);
        }

        public async Task Remove(params object[] id)
        {
            var entity = await this._connection.Set<TEntity>().FindAsync(id);

            if (entity != null)
                this._connection.Remove(entity);

        }

        public async Task SaveAsync() => await this._connection.SaveChangesAsync();
        
    }
}
