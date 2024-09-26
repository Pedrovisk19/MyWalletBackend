using MyWallet.Models.Base;

namespace MyWallet.Models
{
    public class UserMoney : BaseEntity
    {
        public virtual long Income { get; set; }
        public virtual long Outcome { get; set; }
        public virtual long Total { get; set; }
        public virtual long UserMoneyId { get; set; }

    }
}
