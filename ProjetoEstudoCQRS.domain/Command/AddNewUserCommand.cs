using ProjetoEstudoCQRS.domain.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Command
{
    public class AddNewUserCommand : ICommand
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
