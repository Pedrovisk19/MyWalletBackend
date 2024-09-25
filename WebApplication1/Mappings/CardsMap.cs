using FluentNHibernate.Mapping;
using MyWallet.Models;

namespace MyWallet.Mappings
{
    public class UserMoneyMap : ClassMap<UserMoney>
    {
        public UserMoneyMap()
        {
            Table("UserMoney");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Income).Not.Nullable();
            Map(x => x.Outcome).Not.Nullable();
            Map(x => x.Total).Not.Nullable(); 
            Map(x => x.UserMoneyId);
        }
    }
}
