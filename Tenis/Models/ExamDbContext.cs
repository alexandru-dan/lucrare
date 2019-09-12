using Microsoft.EntityFrameworkCore;

namespace ExamenAppDotNet.Models
{
    // DbContext = Unit of Work
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();
            });
        }

        // DbSet = Repository, O tabela din baza de 
        public DbSet<User> Users { get; set; }
    }
}
