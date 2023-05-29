using PizzaApp.Models;
using Microsoft.EntityFrameworkCore;
namespace PizzaApp.Data
{
    public class PizzaContext :DbContext
    {
        public DbSet<Topping> Toppings { get; set; } = null!;
        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public DbSet<Size> Sizes { get; set; } = null!;

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PizzaDb");
            
        }
        public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
        {
           
        }
    }
}
