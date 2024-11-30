using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todolistA.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_persons_personId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_personId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "personId",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "personId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_personId",
                table: "Tasks",
                column: "personId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_persons_personId",
                table: "Tasks",
                column: "personId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
