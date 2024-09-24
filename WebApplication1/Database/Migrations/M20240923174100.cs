using FluentMigrator;

namespace MyWallet.Database.Migrations
{
    [Migration(20240923174100)]
    public class M20240923174100 : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Nome").AsString(255)
                .WithColumn("Senha").AsString(255)
                .WithColumn("Email").AsString(255);
        }

        public override void Down()
        {
        }
    }
}
