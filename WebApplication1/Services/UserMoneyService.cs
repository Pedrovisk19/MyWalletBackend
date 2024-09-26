using MyWallet.Models;
using MyWallet.Models.Repository;
using MyWallet.Services.Implementation;
using System;

namespace MyWallet.Services
{
    public class UserMoneyService : IUserMoneyImplementation
    {

        private readonly IRepository<UserMoney> _repository;
        public UserMoneyService(IRepository<UserMoney> repository) 
        {
            _repository = repository;
        }

        public UserMoney Create(UserMoney UserMoney)
        {
            return _repository.Create(UserMoney);
        }

        public UserMoney FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        
        public List<UserMoney> FindAll()
        {
            return _repository.FindAll();
        }

        public UserMoney Update(UserMoney UserMoney)
        {
            var existingUserMoney = _repository.FindByID(UserMoney.Id);
            if (existingUserMoney == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            // Aqui você pode adicionar a lógica de atualização dos campos
            existingUserMoney.Income = UserMoney.Income; // Exemplo de atualização de um campo
            existingUserMoney.Outcome = UserMoney.Outcome; // Exemplo de atualização de um campo
            return _repository.Update(existingUserMoney);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
