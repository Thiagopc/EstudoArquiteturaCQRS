using ProjetoEstudoCQRS.domain.Command;
using ProjetoEstudoCQRS.domain.Entities;
using ProjetoEstudoCQRS.domain.Interfaces.Command;
using ProjetoEstudoCQRS.domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCQRS.domain.CommandHandler
{
    public class DeleteNewUserCommandHandler : ICommandHandler<DeleteNewUserCommand>
    {
        private readonly IRepositoryBase<Usuario> _repository;
        public DeleteNewUserCommandHandler(IRepositoryBase<Usuario> repository)
        {
            this._repository = repository;
        }

        public async Task Handle(DeleteNewUserCommand command)
        {
            if (command == null || (command.Id  == 0))
                throw new Exception("Invalid Id");

            await this._repository.Remove(command.Id);
            await this._repository.SaveAsync();
        }
    }
}
