using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.infra.Connection.RepositoriesQuery
{
    public abstract class QueryConnection
    {
        private readonly string _strconnection;
        public QueryConnection(IConfiguration configuration) {
            this._strconnection = configuration.GetConnectionString("Value"); ;
        }

        public DbConnection getConnection()
        {
            return new MySqlConnection(this._strconnection);
        }

    }
}
