using Microsoft.EntityFrameworkCore.Migrations;

namespace TP4.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    AbonnementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrixMensuel = table.Column<double>(type: "float", nullable: false),
                    RabaisPourcentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.AbonnementId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoTelephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonnementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Abonnements_AbonnementId",
                        column: x => x.AbonnementId,
                        principalTable: "Abonnements",
                        principalColumn: "AbonnementId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Abonnements",
                columns: new[] { "AbonnementId", "PrixMensuel", "RabaisPourcentage", "Type" },
                values: new object[] { 1, 0.0, 0, "Regulier" });

            migrationBuilder.InsertData(
                table: "Abonnements",
                columns: new[] { "AbonnementId", "PrixMensuel", "RabaisPourcentage", "Type" },
                values: new object[] { 2, 50.0, 10, "Argent" });

            migrationBuilder.InsertData(
                table: "Abonnements",
                columns: new[] { "AbonnementId", "PrixMensuel", "RabaisPourcentage", "Type" },
                values: new object[] { 3, 100.0, 15, "Or" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AbonnementId",
                table: "Clients",
                column: "AbonnementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Abonnements");
        }
    }
}
