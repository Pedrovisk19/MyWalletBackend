using FluentMigrator;

namespace MyWallet.Database.Migrations
{
    [Migration(20240924010200)]

    public class M20240924010200 : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("Users")
                .Row(new { Nome = "Pedro souza", Email = "pedro@teste.com", Senha = "Pedro486" });
        }

        public override void Down()
        {
        }
    }
}
