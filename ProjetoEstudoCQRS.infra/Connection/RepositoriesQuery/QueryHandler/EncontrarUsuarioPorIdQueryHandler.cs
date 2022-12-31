using Dapper;
using ProjetoEstudoCQRS.domain.Common;
using ProjetoEstudoCQRS.domain.Interfaces.Query;
using ProjetoEstudoCQRS.domain.Interfaces.Query.QueryHandlerImplementation;
using ProjetoEstudoCQRS.domain.Query;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.infra.Connection.RepositoriesQuery.QueryHandler
{
    public class EncontrarUsuarioPorIdQueryHandler : IEncontrarUsuarioPorIdQueryHandler
    {
        private readonly QueryConnection _connection;


        public EncontrarUsuarioPorIdQueryHandler(QueryConnection connection)
        {
            this._connection = connection;
        }

        public async Task<IList<UsuarioDisplay>> Handle(EncontrarUsuarioPorIdQuery query)
        {
            using (var conn = this._connection.getConnection())
            {
                await conn.OpenAsync();
                return (await conn.QueryAsync<UsuarioDisplay>("SELECT id as Id, nome as Nome, idade as Idade FROM usuario where id = @id ",
                    new { id = query.Id }))
                    .ToList();
            }
        }



    }
}
