using Microsoft.EntityFrameworkCore.Migrations;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Migrations
{
    public partial class AddTablesManageLivraison_29052021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoyenTransportId",
                table: "Livraison",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeLivraisonId",
                table: "Livraison",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoyenTransportId",
                table: "Colis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeAgenceId",
                table: "Agence",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MoyenTransport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Matricule = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoyenTransport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAgence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAgence", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeLivraison",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLivraison", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livraison_MoyenTransportId",
                table: "Livraison",
                column: "MoyenTransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Livraison_TypeLivraisonId",
                table: "Livraison",
                column: "TypeLivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Agence_TypeAgenceId",
                table: "Agence",
                column: "TypeAgenceId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Agence_TypeAgence_TypeAgenceId",
            //    table: "Agence",
            //    column: "TypeAgenceId",
            //    principalTable: "TypeAgence",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

            migrationBuilder.CreateIndex(
                name: "IX_Colis_MoyenTransportId",
                table: "Colis",
                column: "MoyenTransportId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Colis_MoyenTransport_MoyenTransportId",
            //     table: "Colis",
            //     column: "MoyenTransportId",
            //     principalTable: "MoyenTransport",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livraison_MoyenTransport_MoyenTransportId",
                table: "Livraison",
                column: "MoyenTransportId",
                principalTable: "MoyenTransport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livraison_TypeLivraison_TypeLivraisonId",
                table: "Livraison",
                column: "TypeLivraisonId",
                principalTable: "TypeLivraison",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agence_TypeAgence_TypeAgenceId",
                table: "Agence");

            migrationBuilder.DropForeignKey(
                name: "FK_Colis_MoyenTransport_MoyenTransportId",
                table: "Colis");

            migrationBuilder.DropForeignKey(
                name: "FK_Livraison_MoyenTransport_MoyenTransportId",
                table: "Livraison");

            migrationBuilder.DropForeignKey(
                name: "FK_Livraison_TypeLivraison_TypeLivraisonId",
                table: "Livraison");

            migrationBuilder.DropTable(
                name: "MoyenTransport");

            migrationBuilder.DropTable(
                name: "TypeAgence");

            migrationBuilder.DropTable(
                name: "TypeLivraison");

            migrationBuilder.DropIndex(
                name: "IX_Livraison_MoyenTransportId",
                table: "Livraison");

            migrationBuilder.DropIndex(
                name: "IX_Livraison_TypeLivraisonId",
                table: "Livraison");

            migrationBuilder.DropIndex(
                name: "IX_Colis_MoyenTransportId",
                table: "Colis");

            migrationBuilder.DropIndex(
                name: "IX_Agence_TypeAgenceId",
                table: "Agence");

            migrationBuilder.DropColumn(
                name: "MoyenTransportId",
                table: "Livraison");

            migrationBuilder.DropColumn(
                name: "TypeLivraisonId",
                table: "Livraison");

            migrationBuilder.DropColumn(
                name: "MoyenTransportId",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "TypeAgenceId",
                table: "Agence");
        }
    }
}
