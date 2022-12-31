using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstudoCQRS.domain.Command;
using ProjetoEstudoCQRS.domain.Entities;
using ProjetoEstudoCQRS.domain.Interfaces.Command;
using ProjetoEstudoCQRS.infra.Connection;

namespace ProjetoEstudoCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ConnectionDb _connection;
        private readonly ICommandDispatcher _dispatcher;

        public UsuarioController(ConnectionDb connection, ICommandDispatcher dispatcher)
        {
            this._connection = connection;
            this._dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }


        [HttpGet]
        public  IActionResult List()
        {
            return Ok(this._connection.Usuarios.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddNewUserCommand usuario)
        {

            await this._dispatcher.Send(usuario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this._dispatcher.Send(new DeleteNewUserCommand { Id = id });
            return Ok();
        }


    }
}
