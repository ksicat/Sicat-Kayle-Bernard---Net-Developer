using Microsoft.AspNetCore.Mvc;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinksController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Drink>>> Get()
        {
            return Ok(await _drinkRepository.GetDrinksAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Drink>> Post([FromBody] Drink drink)
        {
            return drink switch
            {
                _ when string.IsNullOrEmpty(drink.Description)
                    => BadRequest($"Post: Drink description cannot be null. - {drink.DrinkId}"),
                _ when drink.Price == 0 && drink.Quantity == 0 && drink.Weight == 0
                    => BadRequest($"Post: Price,Quantiy,Weight are missing fields - {drink.DrinkId}"),
                _ => Accepted(await _drinkRepository.PostDrinkAsync(drink))
            };
        }

        [HttpPut]
        public async Task<ActionResult<Drink>> Put([FromBody] Drink drink)
        {
            return drink switch
            {
                _ when string.IsNullOrEmpty(drink.Description)
                    => BadRequest($"Post: Drink description cannot be null. - {drink.DrinkId}"),
                _ when drink.Price == 0 && drink.Quantity == 0 && drink.Weight == 0
                    => BadRequest($"Post: Price,Quantiy,Weight are missing fields - {drink.DrinkId}"),
                _ => Accepted(await _drinkRepository.PutDrinkAsync(drink))
            };
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) 
        {
            return id switch
            {
                _ when id == 0 
                    => BadRequest($"Post: Invalid Id - {id}"),
                _ => Accepted(await _drinkRepository.RemoveDrinkAsync(id))
            };
        }
    }
}
