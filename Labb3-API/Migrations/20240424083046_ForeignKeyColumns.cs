using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_Interests_InterestId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "FkInterestId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "FkPersonId",
                table: "Interests");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "Link",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Interests_InterestId",
                table: "Link",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_Interests_InterestId",
                table: "Link");

            migrationBuilder.AlterColumn<int>(
                name: "InterestId",
                table: "Link",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkInterestId",
                table: "Link",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Interests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FkPersonId",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_Interests_InterestId",
                table: "Link",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "InterestId");
        }
    }
}
