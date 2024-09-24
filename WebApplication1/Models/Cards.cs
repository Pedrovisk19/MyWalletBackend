namespace MyWallet.Models
{
    public class Cards
    {
        public virtual int Id { get; set; }
        public virtual string Numeros { get; set; }
        public virtual string CodSeguranca { get; set; }
        public virtual string Validade { get; set; }
        public virtual string UserCardId { get; set; }

    }
}
