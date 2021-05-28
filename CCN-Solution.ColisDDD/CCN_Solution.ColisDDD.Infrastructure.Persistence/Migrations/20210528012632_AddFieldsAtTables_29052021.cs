using Microsoft.EntityFrameworkCore.Migrations;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Migrations
{
    public partial class AddFieldsAtTables_29052021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Poid",
                table: "TypeDeColis",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CIN",
                table: "Client",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poid",
                table: "TypeDeColis");

            migrationBuilder.DropColumn(
                name: "CIN",
                table: "Client");
        }
    }
}
