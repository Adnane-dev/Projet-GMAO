﻿// <auto-generated />
using System;
using GMAO.Models.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GMAO.Migrations
{
    [DbContext(typeof(GMAOContext))]
    [Migration("20240227195215_Ado_Entity")]
    partial class Ado_Entity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GMAO.Models.Entities.Clients", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Contrats", b =>
                {
                    b.Property<int>("IdContrat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContrat"), 1L, 1);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TypeContrat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContrat");

                    b.HasIndex("IdClient");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Devis", b =>
                {
                    b.Property<int>("IdDevis")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDevis"), 1L, 1);

                    b.Property<int>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDevis")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDevis");

                    b.HasIndex("ClientIdClient");

                    b.ToTable("Devis", (string)null);
                });

            modelBuilder.Entity("GMAO.Models.Entities.Equipements", b =>
                {
                    b.Property<int>("IdEquipement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipement"), 1L, 1);

                    b.Property<DateTime>("DateGarantie")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInstallation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipement");

                    b.ToTable("Equipements");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Factures", b =>
                {
                    b.Property<int>("IdFacture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFacture"), 1L, 1);

                    b.Property<int>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFacture")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdFacture");

                    b.HasIndex("ClientIdClient");

                    b.ToTable("Factures", (string)null);
                });

            modelBuilder.Entity("GMAO.Models.Entities.Interventions", b =>
                {
                    b.Property<int>("IdIntervention")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIntervention"), 1L, 1);

                    b.Property<int>("ClientIdClient")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateIntervention")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipementIdEquipement")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HeureIntervention")
                        .HasColumnType("time");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TechnicienIdTechnicien")
                        .HasColumnType("int");

                    b.Property<string>("TypeIntervention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIntervention");

                    b.HasIndex("ClientIdClient");

                    b.HasIndex("EquipementIdEquipement");

                    b.HasIndex("TechnicienIdTechnicien");

                    b.ToTable("Interventions", (string)null);
                });

            modelBuilder.Entity("GMAO.Models.Entities.Stocks", b =>
                {
                    b.Property<int>("IdStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStock"), 1L, 1);

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Produit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("IdStock");

                    b.ToTable("Stocks", (string)null);
                });

            modelBuilder.Entity("GMAO.Models.Entities.Techniciens", b =>
                {
                    b.Property<int>("IdTechnicien")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTechnicien"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTechnicien");

                    b.ToTable("Techniciens");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Contrats", b =>
                {
                    b.HasOne("GMAO.Models.Entities.Clients", "Clients")
                        .WithMany("listContrats")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Clients");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Devis", b =>
                {
                    b.HasOne("GMAO.Models.Entities.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientIdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Factures", b =>
                {
                    b.HasOne("GMAO.Models.Entities.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientIdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Interventions", b =>
                {
                    b.HasOne("GMAO.Models.Entities.Clients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientIdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMAO.Models.Entities.Equipements", "Equipement")
                        .WithMany()
                        .HasForeignKey("EquipementIdEquipement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMAO.Models.Entities.Techniciens", "Technicien")
                        .WithMany()
                        .HasForeignKey("TechnicienIdTechnicien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Equipement");

                    b.Navigation("Technicien");
                });

            modelBuilder.Entity("GMAO.Models.Entities.Clients", b =>
                {
                    b.Navigation("listContrats");
                });
#pragma warning restore 612, 618
        }
    }
}
