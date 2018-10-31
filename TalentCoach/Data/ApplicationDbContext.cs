using Microsoft.EntityFrameworkCore;
using TalentCoach.Models;
using TalentCoach.Models.Domain;
using TalentCoach.Models.Mappers;

namespace TalentCoach.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Competentie> Competenties { get; set; }
        public DbSet<Activiteit> Activiteiten { get; set; }
        public DbSet<Richting> Richtingen { get; set; }
        public DbSet<Leerling> Leerlingen { get; set; }
        public DbSet<Werkgever> Werkgevers { get; set; }
        public DbSet<Werkaanbieding> Werkaanbiedingen { get; set; }
        public DbSet<Werkspreuk> Werkspreuken { get; set; }
        public DbSet<AlgemeneInfo> AlgemeneInfo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LeerlingWerkaanbiedingConfiguration());
            modelBuilder.ApplyConfiguration(new LeerlingConfiguration());
        }

        public DbSet<Richting> Richting { get; set; }
    }
}
