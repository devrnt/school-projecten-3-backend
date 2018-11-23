using Microsoft.EntityFrameworkCore;
using TalentCoach.Models;
using TalentCoach.Models.Domain;
using TalentCoach.Models.Mappers;

namespace TalentCoach.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DeelCompetentie> DeelCompetenties { get; set; }
        public DbSet<HoofdCompetentie> HoofdCompetenties { get; set; }
        public DbSet<LeerlingDeelCompetentie> LeerlingDeelCompetenties { get; set; }
        public DbSet<LeerlingHoofdCompetentie> LeerlingHoofdCompetenties { get; set; }
        public DbSet<Richting> Richtingen { get; set; }
        public DbSet<Leerling> Leerlingen { get; set; }
        public DbSet<Werkgever> Werkgevers { get; set; }
        public DbSet<Werkaanbieding> Werkaanbiedingen { get; set; }
        public DbSet<Werkspreuk> Werkspreuken { get; set; }
        public DbSet<AlgemeneInfo> AlgemeneInfo { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<SpecifiekeInfo> SpecifiekeInfo { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LeerlingWerkaanbiedingConfiguration());
            modelBuilder.ApplyConfiguration(new LeerlingConfiguration());
            modelBuilder.ApplyConfiguration(new WerkaanbiedingConfiguration());
        }

        public DbSet<Richting> Richting { get; set; }
    }
}
