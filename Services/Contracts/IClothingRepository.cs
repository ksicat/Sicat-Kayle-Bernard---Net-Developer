using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services
{
   public interface IClothingRepository
    {
       Task<List<Clothing>> GetClothingsAsync();
       Task<List<Clothing>> GetClothingsAsync(int[] ids);
       Task<Clothing> PostClothingAsync(Clothing food);
       Task<Clothing> PutClothingAsync(Clothing food);
       Task<int> RemoveClothingAsync(int Id);
    }
}
