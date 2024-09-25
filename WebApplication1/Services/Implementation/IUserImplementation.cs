using MyWallet.Models;

namespace MyWallet.Services.Implementation
{
    public interface IUserImplementation
    {
        Users Create(Users users);
        Users FindByID(long id);
        List<Users> FindAll();
        Users Update(Users users);
        void Delete(long id);
    }

}
