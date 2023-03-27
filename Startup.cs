using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services;
using Sicat_Kayle_Bernard___Net_Developer.Services.Concretes;
using Sicat_Kayle_Bernard___Net_Developer.Services.Contracts;
using Sicat_Kayle_Bernard___Net_Developer.ViewModels;
using System.Linq;
using static Sicat_Kayle_Bernard___Net_Developer.ViewModels.AppSettings;

namespace Sicat_Kayle_Bernard___Net_Developer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOptions();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sicat_Kayle_Bernard___Net_Developer", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));

            services.AddTransient(p => Mocks.MockApiDbContext.CreateInMemoryContextWithData("ProductsDb"));
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<IClothingRepository, ClothingRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductServices, ProductServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sicat_Kayle_Bernard___Net_Developer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
