using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoEstudoCQRS.infra.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.infra.IoC
{
    public static class ConnectionExtension
    {        
        public static void UseConnection(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Value");
            service.AddDbContext<ConnectionDb>(options => options.UseMySQL(connectionString));
        }
    }
}
