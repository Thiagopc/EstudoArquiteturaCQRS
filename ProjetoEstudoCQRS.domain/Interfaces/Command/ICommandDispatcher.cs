using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Interfaces.Command
{
    public interface ICommandDispatcher
    {
        Task Send<T>(T command) where T : ICommand;
    }
}
