using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMAO.Migrations
{
    public partial class ADo_Entiyu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });
            /*
            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    IdEquipement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInstallation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateGarantie = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.IdEquipement);
                });*/
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    IdStock = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.IdStock);
                });

            migrationBuilder.CreateTable(
                name: "Techniciens",
                columns: table => new
                {
                    IdTechnicien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniciens", x => x.IdTechnicien);
                });

            migrationBuilder.CreateTable(
                name: "Contrats",
                columns: table => new
                {
                    IdContrat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeContrat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrats", x => x.IdContrat);
                    table.ForeignKey(
                        name: "FK_Contrats_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devis",
                columns: table => new
                {
                    IdDevis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDevis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devis", x => x.IdDevis);
                    table.ForeignKey(
                        name: "FK_Devis_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    IdFacture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFacture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.IdFacture);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    IdIntervention = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIntervention = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureIntervention = table.Column<TimeSpan>(type: "time", nullable: false),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false),
                    EquipementIdEquipement = table.Column<int>(type: "int", nullable: false),
                    TechnicienIdTechnicien = table.Column<int>(type: "int", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.IdIntervention);
                    table.ForeignKey(
                        name: "FK_Interventions_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interventions_Equipements_EquipementIdEquipement",
                        column: x => x.EquipementIdEquipement,
                        principalTable: "Equipements",
                        principalColumn: "IdEquipement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interventions_Techniciens_TechnicienIdTechnicien",
                        column: x => x.TechnicienIdTechnicien,
                        principalTable: "Techniciens",
                        principalColumn: "IdTechnicien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrats_ClientIdClient",
                table: "Contrats",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_ClientIdClient",
                table: "Devis",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientIdClient",
                table: "Factures",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_ClientIdClient",
                table: "Interventions",
                column: "ClientIdClient");
            
            /*migrationBuilder.CreateIndex(
                name: "IX_Interventions_EquipementIdEquipement",
                table: "Interventions",
                column: "EquipementIdEquipement");*/

            migrationBuilder.CreateIndex(
                name: "IX_Interventions_TechnicienIdTechnicien",
                table: "Interventions",
                column: "TechnicienIdTechnicien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrats");

            migrationBuilder.DropTable(
                name: "Devis");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Clients");
            /*
            migrationBuilder.DropTable(
                name: "Equipements");*/

            migrationBuilder.DropTable(
                name: "Techniciens");
        }
    }
}
