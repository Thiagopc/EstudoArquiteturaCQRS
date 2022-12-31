using ProjetoEstudoCQRS.domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.CommandToDispatcher
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _service;
        

        public CommandDispatcher(IServiceProvider service)
        {
            this._service = service;
            
        }
        public async Task Send<T>(T command) where T : ICommand
        {
            var handler = _service.GetService(typeof(ICommandHandler<T>));
            
            if (handler != null)
                await ((ICommandHandler<T>)handler).Handle(command);
            else
                throw new Exception($"Command doesn't have any handler {command.GetType().Name}");
        }
    }
}
