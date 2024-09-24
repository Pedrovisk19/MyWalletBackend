using FluentMigrator;

namespace MyWallet.Database.Migrations
{
    [Migration(20240923174100)]
    public class M20240923174100 : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(255)
                .WithColumn("Senha").AsDateTime()
                .WithColumn("Email").AsString(255).Unique();
        }

        public override void Down()
        {
        }
    }
}
