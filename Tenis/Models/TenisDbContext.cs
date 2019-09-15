using Microsoft.EntityFrameworkCore;

namespace Tenis.Models
{
    // DbContext = Unit of Work
    public class TenisDbContext : DbContext
    {
        public TenisDbContext(DbContextOptions<TenisDbContext> options) : base(options)
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
        public DbSet<Fields> Fields { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
