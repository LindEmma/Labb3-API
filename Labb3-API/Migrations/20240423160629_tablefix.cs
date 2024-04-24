using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class tablefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_FkPersonId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interests_FkInterestId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Interests_FkPersonId",
                table: "Interests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_FkInterestId",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "Link");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Interests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Link",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Link",
                table: "Link",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_PersonId",
                table: "Interests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_InterestId",
                table: "Link",
                column: "InterestId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Persons_PersonId",
                table: "Interests");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_Interests_InterestId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Interests_PersonId",
                table: "Interests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Link",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_InterestId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Link");

            migrationBuilder.RenameTable(
                name: "Link",
                newName: "Links");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FkPersonId",
                table: "Interests",
                column: "FkPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FkInterestId",
                table: "Links",
                column: "FkInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Persons_FkPersonId",
                table: "Interests",
                column: "FkPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interests_FkInterestId",
                table: "Links",
                column: "FkInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
