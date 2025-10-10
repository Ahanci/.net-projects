using FluentMigrator;

namespace moon_light_rest_api.Migrations
{
    [Migration(2025100903)]
    public class MakeEmailAndPhoneRequired : Migration
    {
        public override void Up()
        {
            // phonenumber kolonunu NOT NULL yap
            Alter.Column("phonenumber").OnTable("parents").InSchema("public").AsString(20).NotNullable();

            // email kolonunu NOT NULL yap
            Alter.Column("email").OnTable("parents").InSchema("public").AsString(100).NotNullable();
        }

        public override void Down()
        {
            // eski haline geri al (nullable yap)
            Alter.Column("phonenumber").OnTable("parents").InSchema("public").AsString(20).Nullable();
            Alter.Column("email").OnTable("parents").InSchema("public").AsString(100).Nullable();
        }
    }
}
