using Microsoft.EntityFrameworkCore.Migrations;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Migrations
{
    public partial class AddFieldOnTableUser_210621 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Agence");

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Agence",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
