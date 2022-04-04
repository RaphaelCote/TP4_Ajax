using Microsoft.EntityFrameworkCore.Migrations;

namespace TP4.Migrations
{
    public partial class AbonnementIdRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Abonnements_AbonnementId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "AbonnementId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Abonnements_AbonnementId",
                table: "Clients",
                column: "AbonnementId",
                principalTable: "Abonnements",
                principalColumn: "AbonnementId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Abonnements_AbonnementId",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "AbonnementId",
                table: "Clients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Abonnements_AbonnementId",
                table: "Clients",
                column: "AbonnementId",
                principalTable: "Abonnements",
                principalColumn: "AbonnementId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
