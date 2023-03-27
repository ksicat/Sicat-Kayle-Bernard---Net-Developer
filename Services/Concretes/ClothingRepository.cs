using Microsoft.EntityFrameworkCore;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Concretes
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public ClothingRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<List<Clothing>> GetClothingsAsync()
        {
            return await _apiDbContext.Clothings.ToListAsync();
        }
        public async Task<List<Clothing>> GetClothingsAsync(int[] ids)
        {
            return await _apiDbContext.Clothings.Where(w => ids.Any(a=> w.ClothingId == a)).ToListAsync();
        }

        public async Task<Clothing> PostClothingAsync(Clothing clothing)
        {
             _apiDbContext.Clothings.AddRange(clothing);
            await _apiDbContext.SaveChangesAsync();
            return clothing;
        }

        public async Task<Clothing> PutClothingAsync(Clothing clothing)
        {
            _apiDbContext.Clothings.Update(clothing);
            await _apiDbContext.SaveChangesAsync();
            return clothing;
        }

        public async Task<int> RemoveClothingAsync(int Id)
        {
            _apiDbContext.Clothings.Remove(_apiDbContext.Clothings.FirstOrDefault(x => x.ClothingId == Id));
            return await _apiDbContext.SaveChangesAsync(); 
        }
    }
}
