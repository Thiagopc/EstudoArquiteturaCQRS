using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Interfaces.Command
{
    public interface ICommandHandler<T> : ICommandHandlerMark where T : ICommand
    {
        Task Handle(T command);
    }
}
