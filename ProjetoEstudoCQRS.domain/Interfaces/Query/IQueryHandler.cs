using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Interfaces.Query
{
    public interface IQueryHandler<T,Tout> : IQueryHandlerMark where T: IQuery
    {
        Task<IList<Tout>> Handle(T query);
    }
}
