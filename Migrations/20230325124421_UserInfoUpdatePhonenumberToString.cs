using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodsConnected.Migrations
{
    public partial class UserInfoUpdatePhonenumberToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 15,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Users",
                type: "INTEGER",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 15,
                oldNullable: true);
        }
    }
}
