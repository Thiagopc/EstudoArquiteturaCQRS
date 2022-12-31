using ProjetoEstudoCQRS.domain.Interfaces.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Query
{
    public class EncontrarUsuarioPorIdQuery : IQuery
    {
        public int Id { get; set; }
    }
}
