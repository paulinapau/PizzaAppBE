using PizzaApp.Models;
namespace PizzaApp.Interfaces
{
    public interface ISizeRepository
    {
        public Task<List<Size>> GetAllSizes();
    }
}
