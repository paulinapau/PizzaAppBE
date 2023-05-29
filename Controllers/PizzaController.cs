
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using PizzaApp.Interfaces;
namespace PizzaApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        [HttpGet("getTotal")]
        public ActionResult<double> GetPizzaCost([FromQuery] int sizeId, int toppingCounts)
        {
            return Ok(_pizzaRepository.GetPizzaCost(sizeId, toppingCounts));
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreatePizza([FromBody] CreatePizzaDto request)
        {
            var createdPizza = await _pizzaRepository.CreatePizza(request);
            if (createdPizza == null)
            {
                return BadRequest(); // or any other appropriate error response
            }

            return Created("", createdPizza);
        }
        [HttpGet("getAllPizzas")]
        public async Task<ActionResult<List<Pizza>>>GetAllSubmitted()
        {
            return Ok(await _pizzaRepository.GetAllPizzas());
        }
    }
}
