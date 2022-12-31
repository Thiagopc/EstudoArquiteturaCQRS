using ProjetoEstudoCQRS.domain.Interfaces.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.QueryToDispatcher
{
    public class QueryDispatcher : IQueryDispatcher<IQuery>
    {

        private readonly IServiceProvider _service;
        public QueryDispatcher(IServiceProvider service)
        {
            this._service = service;

        }

        public async Task<IList<IResult>> Send<IResult>(IQuery query)
        {
            var handler = _service.GetService(typeof(IQueryDispatcher<IQuery>));

            if (handler != null)
               return await((IQueryDispatcher<IQuery>)handler).Send<IResult>(query);

            else
                throw new Exception($"Command doesn't have any handler {query.GetType().Name}");
        }
    }
}
