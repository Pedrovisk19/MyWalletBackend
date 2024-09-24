using FluentNHibernate.Mapping;
using MyWallet.Models;

namespace MyWallet.Mappings
{
    public class UsersMap : ClassMap<Cards>
	{
		public UsersMap()
		{
			Table("Users");
			Id(x => x.Id).GeneratedBy.Identity();
			Map(x => x.Numeros);
			Map(x => x.Validade);
			Map(x => x.CodSeguranca);
			Map(x => x.UserCardId);
		}
	}
}
