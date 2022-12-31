using ProjetoEstudoCQRS.domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Command
{
    public class DeleteNewUserCommand : ICommand
    {
        public int Id { get; set; }
    }
}
