using PizzaApp.Models;
namespace PizzaApp.Interfaces
{
    public interface IPizzaRepository
    {
        public Task<double> GetPizzaCost(int id, int toppingCounts);
        public Task<Pizza?> CreatePizza(CreatePizzaDto request);
        public Task<List<Pizza>> GetAllPizzas();
    }
}
