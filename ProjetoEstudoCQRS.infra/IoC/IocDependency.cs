﻿using Microsoft.Extensions.DependencyInjection;
using ProjetoEstudoCQRS.domain.Command;
using ProjetoEstudoCQRS.domain.CommandHandler;
using ProjetoEstudoCQRS.domain.CommandToDispatcher;
using ProjetoEstudoCQRS.domain.Interfaces.Command;
using ProjetoEstudoCQRS.domain.Interfaces.Repositories;
using ProjetoEstudoCQRS.infra.Connection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.infra.IoC
{
    public static class IocDependency
    {
        public static void ConfigureDependency(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            service.AddScoped<ICommandHandler<AddNewUserCommand>, AddNewUserCommandHandler>();
            service.AddScoped<ICommandHandler<DeleteNewUserCommand>, DeleteNewUserCommandHandler>();            
            service.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
