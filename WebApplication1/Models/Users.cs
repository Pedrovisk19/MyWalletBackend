namespace MyWallet.Models
{
    public class Users
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Nome { get; set; }
        public virtual int Senha { get; set; }
    }
}
