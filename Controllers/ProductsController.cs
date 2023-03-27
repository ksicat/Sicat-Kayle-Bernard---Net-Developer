using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services.Contracts;
using Sicat_Kayle_Bernard___Net_Developer.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sicat_Kayle_Bernard___Net_Developer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IProductServices _productServices;
        private readonly AppSettings _appSettings;

        public ProductsController(IProductRepository productRepository,IProductServices productServices, IOptions<AppSettings> option)
        {
            _ProductRepository = productRepository;
            _productServices = productServices;
            _appSettings = option.Value;
        }

        // GET: ProductsController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductsViewModel>>> GetAll(decimal between = 0, decimal to = 0 )
        {
            try 
            {
                if (between != 0 && to != 0 ) // For betweeen query
                    return Ok(await _productServices.GetProducts(_appSettings.TypeTax,between,to));

                return Ok(await _productServices.GetProducts(_appSettings.TypeTax, between, to));
            } catch (Exception ex) 
            {
                return BadRequest($"Product : GetAll - Exception error - {ex.Message}");
            }
        }

        // POST ProductsController
        [HttpPost]
        public async Task<ActionResult>Post([FromBody] Product products)
        {
            try
            {
              /*  if (!products.ClothingId.Any() && !products.DrinkId.Any() && !products.FoodId.Any())
                    return NotFound();*/

                var response = await _ProductRepository.PostProductAsync(products);
                if (response > 0)
                    return Ok($"Successfully Insert to database : {response}");

                return BadRequest();
            }
            catch (Exception ex) 
            {
                return BadRequest($"Product : Post - Exeception Error - {ex.Message}");
            }
        }

        // PUT productsController
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            try
            {
                return Ok(await _ProductRepository.PutProductAsync(product));
            }
            catch (Exception ex) 
            {
                return BadRequest($"Product : Put Exception error - {ex.Message}");
            }
        }

        // DELETE ProductsController>
        [HttpDelete]
        public async Task<ActionResult> Delete(int[] productIds)
        {
            try 
            {
                return Ok(await _ProductRepository.RemoveProductAsync(productIds));
            } 
            catch(Exception ex)
            {
                return BadRequest($"Product : Delete Exception Error - {ex.Message}");
            }
        }
    }
}
