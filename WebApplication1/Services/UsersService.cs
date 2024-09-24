using MyWallet.BaseCollections;
using MyWallet.Models;

namespace MyWallet.Services
{
    public class UsersService : BaseService<Users>
    {
        public UsersService(IRepository<Users> repository) : base(repository)
        {
        }

        public override Task<IEnumerable<Users>> ListContent()
        {
            return base.ListContent();
        }

        public override Task FillContentAsync(Users entity)
        {
            return base.FillContentAsync(entity);
        }
    }
}
