using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, Name = "Atikul", DisplayOrder = "1" },
                 new Category { Id = 2, Name = "Ismail", DisplayOrder = "2" },
                 new Category { Id = 3, Name = "Mominul", DisplayOrder = "3" }
                );
        }

    }
}
