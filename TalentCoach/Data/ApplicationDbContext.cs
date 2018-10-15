using Microsoft.EntityFrameworkCore;
using TalentCoach.Models;

namespace TalentCoach.Data {
	public class ApplicationDbContext : DbContext {
		public DbSet<Competentie> Competenties { get; set; }
		public DbSet<Activiteit> Activiteiten { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
		}
	}
}
