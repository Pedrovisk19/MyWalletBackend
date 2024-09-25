using MyWallet.Models.Base;

namespace MyWallet.Models
{
    public class Users : BaseEntity
    {
        public virtual string Email { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Senha { get; set; }
    }
}
