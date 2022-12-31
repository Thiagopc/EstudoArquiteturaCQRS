using ProjetoEstudoCQRS.domain.Common;
using ProjetoEstudoCQRS.domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Interfaces.Query.QueryHandlerImplementation
{
    public interface IEncontrarUsuarioPorIdQueryHandler : IQueryHandler<EncontrarUsuarioPorIdQuery, UsuarioDisplay>
    {
    }
}
