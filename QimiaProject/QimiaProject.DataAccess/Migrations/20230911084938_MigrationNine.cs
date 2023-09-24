using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QimiaProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "RequestBookName",
                table: "Requests",
                newName: "BookName");

            migrationBuilder.RenameColumn(
                name: "RequestBookAuthor",
                table: "Requests",
                newName: "BookAuthor");

            migrationBuilder.AlterColumn<int>(
                name: "UserStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserNo",
                table: "Requests",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNo",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Requests",
                newName: "RequestBookName");

            migrationBuilder.RenameColumn(
                name: "BookAuthor",
                table: "Requests",
                newName: "RequestBookAuthor");

            migrationBuilder.AlterColumn<int>(
                name: "UserStatus",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
