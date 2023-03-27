using Microsoft.EntityFrameworkCore;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Mocks
{
    public class MockApiDbContext
    {
        public static ApiDbContext CreateInMemoryContextWithData(string dbName) 
        {
            DbContextOptions<ApiDbContext> options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            ApiDbContext apiDbContext =  new ApiDbContext(options);
            return apiDbContext;
        }
    }
}
