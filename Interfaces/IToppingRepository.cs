using PizzaApp.Models;
namespace PizzaApp.Interfaces
{
    public interface IToppingRepository
    {
        public Task<List<Topping>> GetAllToppings();
    }
}
