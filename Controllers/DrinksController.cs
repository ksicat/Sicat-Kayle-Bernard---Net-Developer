using Microsoft.AspNetCore.Mvc;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothingsController : ControllerBase
    {
        private readonly IClothingRepository _clothingRepository;

        public ClothingsController(IClothingRepository clothingRepository)
        {
            _clothingRepository = clothingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clothing>>> Get()
        {
            return Ok(await _clothingRepository.GetClothingsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Clothing>> Post([FromBody] Clothing clothing)
        {
            return clothing switch
            {
                _ when string.IsNullOrEmpty(clothing.Description)
                    => BadRequest($"Post: Clothing description cannot be null. - {clothing.ClothingId}"),
                _ when clothing.Price == 0 && clothing.Quantity == 0 && clothing.Weight == 0
                    => BadRequest($"Post: Price,Quantiy,Weight are missing fields - {clothing.ClothingId}"),
                _ => Accepted(await _clothingRepository.PostClothingAsync(clothing))
            };
        }

        [HttpPut]
        public async Task<ActionResult<Clothing>> Put([FromBody] Clothing clothing)
        {
            return clothing switch
            {
                _ when string.IsNullOrEmpty(clothing.Description)
                    => BadRequest($"Post: Clothing description cannot be null. - {clothing.ClothingId}"),
                _ when clothing.Price == 0 && clothing.Quantity == 0 && clothing.Weight == 0
                    => BadRequest($"Post: Price,Quantiy,Weight are missing fields - {clothing.ClothingId}"),
                _ => Accepted(await _clothingRepository.PutClothingAsync(clothing))
            };
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) 
        {
            return id switch
            {
                _ when id == 0 
                    => BadRequest($"Post: Invalid Id - {id}"),
                _ => Accepted(await _clothingRepository.RemoveClothingAsync(id))
            };
        }
    }
}
