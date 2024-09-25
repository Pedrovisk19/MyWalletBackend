using MyWallet.Models.Base;

namespace MyWallet.Models
{
    public class UserMoney : BaseEntity
    {
        public virtual string Numeros { get; set; }
        public virtual string CodSeguranca { get; set; }
        public virtual string Validade { get; set; }
        public virtual string UserCardId { get; set; }

    }
}
