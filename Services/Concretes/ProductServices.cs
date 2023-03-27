using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services.Contracts;
using Sicat_Kayle_Bernard___Net_Developer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sicat_Kayle_Bernard___Net_Developer.ViewModels.AppSettings;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Concretes
{
    public class ProductServices : IProductServices
    {
   
        private readonly IProductRepository _productRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IClothingRepository _clothingRepository;
        private readonly IDrinkRepository _drinkRepository;

        public ProductServices(IProductRepository productRepository, IFoodRepository foodRepository, IClothingRepository clothingRepository, IDrinkRepository drinkRepository)
        {
            _productRepository = productRepository;
            _foodRepository = foodRepository;
            _clothingRepository = clothingRepository;
            _drinkRepository = drinkRepository;
        }

        public async Task<IEnumerable<Product>> InsertProductsServices(ProductsViewModel productViewModel)
        {
            if (productViewModel.ClothingId.Any()) 
            {
                Product ClothingProducts = new Product();
                foreach (var clothingIds in productViewModel.ClothingId)
                {
                    ClothingProducts.ClothingId = clothingIds;
                    await _productRepository.PostProductAsync(ClothingProducts);
                };
            } else  if (productViewModel.FoodId.Any()) {
                Product FoodProducts = new Product();
                foreach (var foodIds in productViewModel.FoodId)
                {
                    FoodProducts.FoodId = foodIds;
                    await _productRepository.PostProductAsync(FoodProducts);
                };
            } else {
            
            }
            return null;
        }
        public async Task<IEnumerable<GetProductsViewModel>> GetProducts(TypeTax typeTax , decimal between , decimal to) 
        {
            var products = await _productRepository.GetProductsAsync();

            IEnumerable<Clothing> clothings = await _clothingRepository.GetClothingsAsync(products.Select(s => s.ClothingId).ToArray());
            IEnumerable<Food> foods = await _foodRepository.GetFoodsAsync(products.Select(s => s.FoodId).ToArray());
            IEnumerable<Drink> drinks = await _drinkRepository.GetDrinksAsync(products.Select(s => s.DrinkId).ToArray());

          List<GetProductsViewModel> getClothingsViewModels = clothings.Join(products,
              clothingJoined => clothingJoined.ClothingId,
              products => products.ClothingId,
              (clothingJoined,productsJoined) =>  new { clothingJoined, productsJoined})
              .Select(s => new GetProductsViewModel()
              {
                  ProductId = s.productsJoined.ProductId,
                  Description = s.clothingJoined.Description,
                  Price = s.clothingJoined.Price,
                  Quantity = s.clothingJoined.Quantity,
                  Category = s.productsJoined.Category
              })
                .ToList();

            getClothingsViewModels.ForEach(x =>
            {
                x.FinalPrice = GetFinal(x.Price, x.Quantity,typeTax.Clothing);
            }); 

             List <GetProductsViewModel> getFoodsViewModels = foods.Join(products,
              foodsJoined => foodsJoined.FoodId,
              products => products.FoodId,
              (foodsJoined, productsJoined) => new { foodsJoined, productsJoined })
              .Select(s => new GetProductsViewModel()
              {
                  ProductId = s.productsJoined.ProductId,
                  Description = s.foodsJoined.Description,
                  Price = s.foodsJoined.Price,
                  Quantity = s.foodsJoined.Quantity,
                  Category = s.productsJoined.Category
              })
                .ToList();

            getFoodsViewModels.ForEach(x =>
            {
                x.FinalPrice = GetFinal(x.Price, x.Quantity,typeTax.Food);
            });

            List<GetProductsViewModel> getDrinksViewModels = drinks.Join(products,
            drinksJoined => drinksJoined.DrinkId,
            products => products.DrinkId,
            (drinksJoined, productsJoined) => new { drinksJoined, productsJoined })
            .Select(s => new GetProductsViewModel()
            {
                ProductId = s.productsJoined.ProductId,
                Description = s.drinksJoined.Description,
                Price = s.drinksJoined.Price,
                Quantity = s.drinksJoined.Quantity,
                Category = s.productsJoined.Category
            })
              .ToList();

            getDrinksViewModels.ForEach(x =>
            {
                x.FinalPrice = GetFinal(x.Price, x.Quantity,typeTax.Drink);
            });

            var returnvalue = getClothingsViewModels.Union(getFoodsViewModels).Union(getDrinksViewModels);


            /* var listOfProducts = products
                 .Join(clothings,
                 productsJoined => productsJoined.ClothingId,
                 clothingsJoined => clothingsJoined.ClothingId,
                 (productsJoined, clothingJoined) => new { productsJoined, clothingJoined })
                 .Join(foods,
                 foodsJoined => foodsJoined.productsJoined.FoodId,
                 productsFoods => productsFoods.FoodId,
                 (foodsJoined, productsFoods) => new { foodsJoined, productsFoods })
                 .Join(drinks,
                 drinksJoined => drinksJoined.foodsJoined.productsJoined.DrinkId,
                 productDrinksJoined => productDrinksJoined.DrinkId,
                 (drinksJoined, productDrinksJoined) => new { drinksJoined, productDrinksJoined })
                 .Select(s => new GetProductsViewModel()
                 {
                     ProductId = s.drinksJoined.foodsJoined.productsJoined.ProductId,
                     Description = GetDescription(s.drinksJoined.productsFoods.Description,s.drinksJoined.foodsJoined.clothingJoined.Description,s.productDrinksJoined.Description),
                     Price = GetPrice(s.drinksJoined.foodsJoined.clothingJoined.Price != 0 ? s.drinksJoined.foodsJoined.clothingJoined.Price : s.drinksJoined.productsFoods.Price, s.productDrinksJoined.Price),
                     Quantity = GetQuantity(s.drinksJoined.foodsJoined.clothingJoined.Quantity != 0 ? s.drinksJoined.foodsJoined.clothingJoined.Quantity : s.drinksJoined.productsFoods.Quantity, s.productDrinksJoined.Quantity),
                     Category = s.drinksJoined.foodsJoined.productsJoined.Category
                 })
                 .ToList();

             listOfProducts.ForEach(x =>
             {
                 x.FinalPrice = GetFinal(x.Price, x.Quantity);
             });*/

            if (between != 0 && to != 0)
                return returnvalue.Where(x => x.FinalPrice >= between).Where(a => a.FinalPrice <= to).ToList();

            return returnvalue;
        }

        private decimal GetFinal(double price, int quantity,decimal tax) 
        {
            return (decimal)price * quantity + ((decimal)price * tax);
        }
        private int GetQuantity(int clothingAndFoodQuantity , int drinkQuantity) 
        {
            return clothingAndFoodQuantity != 0 ? clothingAndFoodQuantity : drinkQuantity;
        }
        private double GetPrice(double clothingAndFoodPrice,  double drinkPrice) 
        {
            return clothingAndFoodPrice != 0 ? clothingAndFoodPrice: drinkPrice;
        }

        private string GetDescription(string foodDescription,string clothingDescription, string drinkDescription) 
        {
            var returnValue = "";

            return returnValue switch
            {
                _ when !string.IsNullOrWhiteSpace(foodDescription)
                    => foodDescription,
                _ when !string.IsNullOrWhiteSpace(clothingDescription)
                    => clothingDescription,
                _ => drinkDescription
            };
        }
    }
}
