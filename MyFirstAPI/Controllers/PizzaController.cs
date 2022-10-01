using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;
using MyFirstAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        // GET: api/<PizzaController>
        [HttpGet]
        public ActionResult<List<Pizza>> Get() => 
            PizzaService.GetAll();

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                   return NotFound();

            return pizza;
        }

        // POST api/<PizzaController>
        [HttpPost]
        public IActionResult Store(Pizza pizza)
        {
            PizzaService.Add(pizza);

            return CreatedAtAction(nameof(Store), new { id = pizza.Id }, pizza);
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            var existingPizza = PizzaService.Get(id);

            if (id != pizza.Id)
                return BadRequest();

            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public IActionResult Destroy(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
