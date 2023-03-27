using Microsoft.AspNetCore.Mvc;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;

        public FoodsController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Food>>> Get()
        {
            return Ok(await _foodRepository.GetFoodsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Food>> Post([FromBody] Food food)
        {
            return food switch
            {
                _ when string.IsNullOrEmpty(food.Description)
                    => BadRequest($"Post: Food description cannot be null. - {food.FoodId}"),
                _ when food.Price == 0 && food.Quantity == 0 && food.Weight == 0
                    => BadRequest($"Post: Price,Quantiy,Weight are missing fields - {food.FoodId}"),
                _ => Accepted(await _foodRepository.PostFoodAsync(food))
            };
        }

        [HttpPut]
        public async Task<ActionResult<Food>> Put([FromBody] Food food)
        {
            return food switch
            {
                _ when string.IsNullOrEmpty(food.Description)
                    => BadRequest($"Post: Food description cannot be null. - {food.FoodId}"),
                _ when food.Price == 0 && food.Quantity == 0 && food.Weight == 0
                    => BadRequest($"Post: Price,Quantiy,Weight are missing fields - {food.FoodId}"),
                _ => Accepted(await _foodRepository.PutFoodAsync(food))
            };
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) 
        {
            return id switch
            {
                _ when id == 0 
                    => BadRequest($"Post: Invalid Id - {id}"),
                _ => Accepted(await _foodRepository.RemoveFoodAsync(id))
            };
        }
    }
}
