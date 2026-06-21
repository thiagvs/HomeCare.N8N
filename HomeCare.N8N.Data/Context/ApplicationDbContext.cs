using HomeCare.N8N.Domain.Medications;
using Microsoft.EntityFrameworkCore;

namespace HomeCare.N8N.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Medication> Medication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dev");

            base.OnModelCreating(modelBuilder);
        }
    }
}
