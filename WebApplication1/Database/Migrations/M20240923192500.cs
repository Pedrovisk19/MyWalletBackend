using FluentMigrator;

namespace MyWallet.Database.Migrations
{
    [Migration(20240923192500)]
    public class M20240923192500 : Migration
    {
        public override void Up()
        {
            Create.Table("UserMoney")
                .WithColumn("Id").AsInt64().NotNullable().Identity().PrimaryKey()
                .WithColumn("Income").AsString(255)
                .WithColumn("Outcome").AsInt64()
                .WithColumn("Total").AsString(255)
                .WithColumn("UserMoneyId").AsInt64();
        }

        public override void Down()
        {
        }
    }
}
