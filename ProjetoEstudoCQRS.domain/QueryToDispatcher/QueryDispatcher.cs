using ProjetoEstudoCQRS.domain.Interfaces.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.QueryToDispatcher
{
    public class QueryDispatcher : IQueryDispatcher
    {

        private readonly IServiceProvider _service;
        public QueryDispatcher(IServiceProvider service)
        {
            this._service = service;

        }

        public async Task<IList<Tout>> Send<Tin, Tout>(Tin query) where Tin : IQuery
        {
            var handler = _service.GetService(typeof(IQueryHandler<Tin, Tout>));

            if (handler != null)
                return await ((IQueryHandler<Tin, Tout>)handler).Handle(query);

            else
                throw new Exception($"Command doesn't have any handler {query.GetType().Name}");
        }


    }
}
