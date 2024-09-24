using FluentNHibernate.Mapping;
using MyWallet.Models;

namespace MyWallet.Mappings
{
    public class CardsMap : ClassMap<Cards>
    {
        public CardsMap()
        {
            Table("Cards");
            Id(x => x.Id).GeneratedBy.Identity(); 
            Map(x => x.Numeros).Not.Nullable(); 
            Map(x => x.Validade).Not.Nullable();
            Map(x => x.CodSeguranca).Not.Nullable(); 
            Map(x => x.UserCardId);
        }
    }
}
