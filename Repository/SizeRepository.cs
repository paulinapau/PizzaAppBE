using PizzaApp.Models;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Interfaces;
namespace PizzaApp.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly PizzaContext _dbContext;
        private bool _isInitialized;
        private readonly object _lock = new object();
        public SizeRepository(PizzaContext db)
        {
            _dbContext = db;
            InitializeSizes();

        }
        public async Task<List<Size>> GetAllSizes()
        {
            return await _dbContext.Sizes.ToListAsync();
        }
        private async void InitializeSizes()
        {
            if (_dbContext.Sizes.Any())
            {
                return ;
            }

            var sizes = new List<Size>
            {
                new Size { Name = "Small" },
                new Size { Name = "Medium" },
                new Size { Name = "Large" },
            };

            await _dbContext.Sizes.AddRangeAsync(sizes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
