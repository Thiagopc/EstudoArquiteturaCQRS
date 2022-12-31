using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.Interfaces.Query
{
    public interface IQueryDispatcher<T> where T: IQuery
    {
        Task<IList<Tresult>> Send<Tresult>(T query) ;
    }
}
