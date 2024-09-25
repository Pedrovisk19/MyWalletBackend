using MyWallet.Models;
using MyWallet.Models.Repository;
using MyWallet.Services.Implementation;
using System;

namespace MyWallet.Services
{
    public class UsersService : IUserImplementation
    {

        private readonly IRepository<Users> _repository;
        public UsersService(IRepository<Users> repository) 
        {
            _repository = repository;
        }

        public Users Create(Users users)
        {
            return _repository.Create(users);
        }

        public Users FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public List<Users> FindAll()
        {
            return _repository.FindAll();
        }

        public Users Update(Users users)
        {
            var existingUser = _repository.FindByID(users.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            // Aqui você pode adicionar a lógica de atualização dos campos
            existingUser.Nome = users.Nome; // Exemplo de atualização de um campo
            existingUser.Email = users.Email; // Exemplo de atualização de um campo
            existingUser.Senha = users.Senha; // Exemplo de atualização de um campo
            return _repository.Update(existingUser);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
