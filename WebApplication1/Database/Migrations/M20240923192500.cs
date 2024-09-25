using FluentMigrator;

namespace MyWallet.Database.Migrations
{
    [Migration(20240923192500)]
    public class M20240923192500 : Migration
    {
        public override void Up()
        {
            Create.Table("Cards")
                .WithColumn("Id").AsInt64().NotNullable().Identity().PrimaryKey()
                .WithColumn("Numeros").AsString(255)
                .WithColumn("CodSeguranca").AsInt64()
                .WithColumn("Validade").AsString(255)
                .WithColumn("UserCardId").AsInt64();
        }

        public override void Down()
        {
        }
    }
}
