using GMAO.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GMAO.Models.Connection
{
    public class GMAOContext : DbContext
    {
     /*   public GMAOContext()
        {
        }

        public GMAOContext(DbContextOptions<GMAOContext> options) : base(options)
        {

        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-K8IAMOO\SQLEXPRESS01;Initial Catalog=GMAO_DB;Integrated Security=True;");
        }

        public DbSet<Contrats> Contrats { get; set; }
        public DbSet<Devis> Devis { get; set; }
        public DbSet<Factures> Factures { get; set; }
        public DbSet<Interventions> Interventions { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Techniciens> Techniciens {get; set;}




        /*
            
                    protected override void OnModelCreating(ModelBuilder modelBuilder)
                    {
                        modelBuilder.Entity<Contrats>().ToTable("Contrats");
                        modelBuilder.Entity<Devis>().ToTable("Devis");
                        modelBuilder.Entity<Factures>().ToTable("Factures");
                        modelBuilder.Entity<Interventions>().ToTable("Interventions");
                        modelBuilder.Entity<Stocks>().ToTable("Stocks"); // Corrected typo: "Stocts" to "Stocks"
                    }*/

    }
}
