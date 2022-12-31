using Microsoft.AspNetCore.Mvc;
using ProjetoEstudoCQRS.domain.Command;
using ProjetoEstudoCQRS.domain.Common;
using ProjetoEstudoCQRS.domain.Interfaces.Command;
using ProjetoEstudoCQRS.domain.Interfaces.Query;
using ProjetoEstudoCQRS.domain.Query;
using ProjetoEstudoCQRS.infra.Connection;

namespace ProjetoEstudoCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ConnectionDb _connection;
        private readonly ICommandDispatcher _dispatchercommand;
        private readonly IQueryDispatcher _dispatcherquery;

        public UsuarioController(ConnectionDb connection, ICommandDispatcher dispatchercommand, IQueryDispatcher dispatcherquery)
        {
            this._connection = connection;
            this._dispatchercommand = dispatchercommand;            
            this._dispatcherquery = dispatcherquery;            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {            
            var result = await this._dispatcherquery.Send<EncontrarUsuarioPorIdQuery, UsuarioDisplay>(new EncontrarUsuarioPorIdQuery() { Id = id });
            return Ok(result);
        }


        [HttpGet]
        public  IActionResult List()
        {
            return Ok(this._connection.Usuarios.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNewUserCommand usuario)
        {
            await this._dispatchercommand.Send(usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this._dispatchercommand.Send(new DeleteNewUserCommand { Id = id });
            return Ok();
        }


    }
}
