using MyWallet.Models;

namespace MyWallet.Services.Implementation
{
    public interface IUserMoneyImplementation
    {
        UserMoney Create(UserMoney userMoney);
        UserMoney FindByID(long id);
        UserMoney Update(UserMoney userMoney);
        void Delete(long id);
    }
}
