using Microsoft.EntityFrameworkCore.Migrations;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Migrations
{
    public partial class AddFieldOnTableUser_22h42 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Agence",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Agence");
        }
    }
}
