using Microsoft.EntityFrameworkCore;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Concretes
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public FoodRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<List<Food>> GetFoodsAsync()
        {
            return await _apiDbContext.Foods.ToListAsync();
        }
        public async Task<List<Food>> GetFoodsAsync(int[] ids)
        {
            return await _apiDbContext.Foods.Where(w => ids.Any(a => w.FoodId == a)).ToListAsync();
        }

        public async Task<Food> PostFoodAsync(Food food)
        {
             _apiDbContext.Foods.AddRange(food);
            await _apiDbContext.SaveChangesAsync();
            return food;
        }

        public async Task<Food> PutFoodAsync(Food food)
        {
            _apiDbContext.Foods.Update(food);
            await _apiDbContext.SaveChangesAsync();
            return food;
        }

        public async Task<int> RemoveFoodAsync(int Id)
        {
            _apiDbContext.Foods.Remove(_apiDbContext.Foods.FirstOrDefault(x => x.FoodId == Id));
            return await _apiDbContext.SaveChangesAsync(); 
        }
    }
}
