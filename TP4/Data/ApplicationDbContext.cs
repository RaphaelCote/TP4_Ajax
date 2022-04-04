using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TP4.Models;

namespace TP4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Abonnement> abonnements = new()
            {
                new Abonnement() { AbonnementId = 1, Type = "Regulier", PrixMensuel = 0, RabaisPourcentage = 0 },
                new Abonnement() { AbonnementId = 2, Type = "Argent", PrixMensuel = 50, RabaisPourcentage = 10 },
                new Abonnement() { AbonnementId = 3, Type = "Or", PrixMensuel = 100, RabaisPourcentage = 15 }
            };
            modelBuilder.Entity<Abonnement>().HasData(abonnements);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
    }
}
