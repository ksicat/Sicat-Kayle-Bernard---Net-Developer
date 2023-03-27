using Microsoft.EntityFrameworkCore;

namespace Sicat_Kayle_Bernard___Net_Developer.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductsDb");
        }
        public DbSet<Clothing> Clothings { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
