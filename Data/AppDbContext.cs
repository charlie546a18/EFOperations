using Microsoft.EntityFrameworkCore;

namespace EFOperations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title = "INR", Description = "Indian Rupees" },
                new Currency() { Id = 2, Title = "Dollar", Description = "US Dollar" },
                new Currency() { Id = 3, Title = "Euro", Description = "Eropian Currency" },
                new Currency() { Id = 4, Title = "Dinar", Description = "UAE Currency" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "English", Description = "English" },
                new Language() { Id = 2, Title = "Marathi", Description = "Marathi" },
                new Language() { Id = 3, Title = "Gujrati", Description = "Gujrati" },
                new Language() { Id = 4, Title = "Punjabi", Description = "Punjabi" }
                );
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
    }
}
