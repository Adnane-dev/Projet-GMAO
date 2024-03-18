using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMAO.Migrations
{
    public partial class Ado_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrats_Clients_ClientIdClient",
                table: "Contrats");

            migrationBuilder.RenameColumn(
                name: "ClientIdClient",
                table: "Contrats",
                newName: "IdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Contrats_ClientIdClient",
                table: "Contrats",
                newName: "IX_Contrats_IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrats_Clients_IdClient",
                table: "Contrats",
                column: "IdClient",
                principalTable: "Clients",
                principalColumn: "IdClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrats_Clients_IdClient",
                table: "Contrats");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Contrats",
                newName: "ClientIdClient");

            migrationBuilder.RenameIndex(
                name: "IX_Contrats_IdClient",
                table: "Contrats",
                newName: "IX_Contrats_ClientIdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrats_Clients_ClientIdClient",
                table: "Contrats",
                column: "ClientIdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
