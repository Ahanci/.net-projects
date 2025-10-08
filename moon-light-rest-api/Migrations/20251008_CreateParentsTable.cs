using FluentMigrator;

namespace moon_light_rest_api.Migrations
{
    [Migration(2025100801)]
    public class CreateParentsTable : Migration
    {
        public override void Up()
        {
            Create.Table("parents").InSchema("public")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString(100).NotNullable()
                .WithColumn("phonenumber").AsString(20).Nullable()
                .WithColumn("email").AsString(100).Nullable();
        }

        public override void Down()
        {
            Delete.Table("parents").InSchema("public");
        }
    }
}
