using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Data;
using PizzaApp.Models;
using PizzaApp.Interfaces;

namespace PizzaApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToppingController : Controller
    {
        private readonly IToppingRepository _toppingRepository;

        public ToppingController(IToppingRepository toppingRepository)
        {
            _toppingRepository = toppingRepository;
        }
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Topping>>> GetAll()
        {
            return Ok(await _toppingRepository.GetAllToppings());
        }



    }
}
