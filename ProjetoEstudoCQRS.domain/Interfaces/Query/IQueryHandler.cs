using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Interfaces.Query
{
    public interface IQueryHandler<TinQuery,TResponse>  where TinQuery: IQuery
    {
        Task<IList<TResponse>> Handle(TinQuery query);
    }
}
