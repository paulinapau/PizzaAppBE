using PizzaApp.Models;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Interfaces;

namespace PizzaApp.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaContext _dbContext;
        public PizzaRepository(PizzaContext db)
        {
            _dbContext = db;
        }

        public async Task<Pizza?> CreatePizza(CreatePizzaDto request)
        {
            if (request == null)
            {
                return null;
            }
            
            var newToppingsNames = await _dbContext.Toppings
            .AsNoTracking()
            .Where(t => request.SelectedToppings.Contains(t.Id))
            .Select(t => t.Name)
            .ToArrayAsync();

            var newSize = await _dbContext.Sizes.FirstOrDefaultAsync(t => t.Id == request.SelectedSize);

            if (newSize == null || newToppingsNames == null)
            {
                return null;
            }

            string combinedString = string.Join("; ", request.SelectedToppingsCount.Select((count, index) => $" {count}x {newToppingsNames[index]}"));
            var newPizza = new Pizza
            {
                Size = newSize,
                TotalSum = request.TotalSum,
                ToppingsNames = combinedString,
            };
            
            await _dbContext.Pizzas.AddAsync(newPizza);
            await _dbContext.SaveChangesAsync();

            return newPizza;
        }

        public async Task<List<Pizza>> GetAllPizzas()
        {
            return await _dbContext.Pizzas.Include(p => p.Size).ToListAsync();
        }

        public Task<double> GetPizzaCost(int Sizeid, int toppingCounts)
        {
            double total = 0;
            if (Sizeid == 1)
                total = 8;
            else if (Sizeid == 2)
                total = 10;
            else if (Sizeid == 3)
                total = 12;
            total += toppingCounts;
            if (toppingCounts > 3)
                total *= 0.9;

            return Task.FromResult(Math.Round(total, 2));
        }
    }
}
