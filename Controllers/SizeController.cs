using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using PizzaApp.Interfaces;

namespace PizzaApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SizeController : Controller
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Size>>> GetAll()
        {
            return Ok(await _sizeRepository.GetAllSizes());
        }
    }
}
