using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class second3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_Id",
                table: "UserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_userId",
                table: "UserRoles",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_userId",
                table: "UserRoles",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_userId",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_userId",
                table: "UserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_Id",
                table: "UserRoles",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
