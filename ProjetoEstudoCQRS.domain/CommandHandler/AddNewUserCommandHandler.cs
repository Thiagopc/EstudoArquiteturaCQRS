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
    public class AddNewUserCommandHandler : ICommandHandler<AddNewUserCommand>
    {
        private readonly IRepositoryBase<Usuario> _repository;
        public AddNewUserCommandHandler(IRepositoryBase<Usuario> repository)
        {
            this._repository = repository;
        }

        public async Task Handle(AddNewUserCommand command)
        {
            if (!this.isValid(command))
                //Falta uma melhor maneira de retornar o que realmente está inválido/propriedades
                throw new Exception("Command invalid");

            var entity = this.commandToEntity(command);
            this._repository.Add(entity);
            await this._repository.SaveAsync();

        }


        private Usuario commandToEntity(AddNewUserCommand command)
        {
            return new Usuario
            {
                Idade = command.Idade,
                Nome = command.Nome
            };
        }

        private bool isValid(AddNewUserCommand command)
        {
            if (command.Idade < 0)
                return false;

            if (string.IsNullOrEmpty(command.Nome))
                return false;

            return true;
        }
    }
}
