using PizzaApp.Models;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Interfaces;
namespace PizzaApp.Repository
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly PizzaContext _dbContext;

        public ToppingRepository(PizzaContext db)
        {
            _dbContext = db;
            InitializeToppings();
        }
        
        public Task<List<Topping>> GetAllToppings()
        {
            return _dbContext.Toppings.ToListAsync();
        }

        private void InitializeToppings()
        {
            if (_dbContext.Toppings.Any())
            {
                return;
            }

            var toppings = new List<Topping>
            {
                new Topping { Name = "Cheese" },
                new Topping { Name = "Pepperoni" },
                new Topping { Name = "Onions" },
                new Topping { Name = "Tomatoes" },
                new Topping { Name = "Chicken" },
                new Topping { Name = "Bacon" },
                new Topping { Name = "Mushroom" },
                new Topping { Name = "Pineapple" },
                new Topping { Name = "Jalapeño" }
            };

            _dbContext.Toppings.AddRangeAsync(toppings);
            _dbContext.SaveChangesAsync();
        }
    }

}
