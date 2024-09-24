using FluentMigrator;

namespace MyWallet.Database.Migrations
{
    [Migration(20240923192500)]
    public class M20240923192500 : Migration
    {
        public override void Up()
        {
            Create.Table("Cards")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Numeros").AsString(255)
                .WithColumn("CodSeguranca").AsInt32()
                .WithColumn("Validade").AsString(255)
                .WithColumn("UserCardId").AsInt32();
        }

        public override void Down()
        {
        }
    }
}
