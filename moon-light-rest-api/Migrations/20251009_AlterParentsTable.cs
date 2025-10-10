using FluentMigrator;

namespace moon_light_rest_api.Migrations
{
    [Migration(2025100902)]
    public class MakeEmailAndPhoneUnique : Migration
    {
        public override void Up()
        {
            Create.Index("IX_Parents_Email")
                .OnTable("parents").OnColumn("email").Unique();

            Create.Index("IX_Parents_PhoneNumber")
                .OnTable("parents").OnColumn("phonenumber").Unique();
        }

        public override void Down()
        {
            Delete.Index("IX_Parents_Email").OnTable("parents");
            Delete.Index("IX_Parents_PhoneNumber").OnTable("parents");
        }
    }
}
