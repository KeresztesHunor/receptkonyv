using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class AppDbContext(IConfiguration config) : DbContext
    {
        IConfiguration config { get; } = config;

        public DbSet<Kategoria> Kategoriak { get; set; }
        public DbSet<Recept> Receptek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>()
                .HasMany(kategoria => kategoria._Receptek)
                .WithOne(recept => recept._KatId)
                .HasForeignKey(recept => recept.KatId)
                .OnDelete(DeleteBehavior.Restrict)
            ;
        }
    }
}
