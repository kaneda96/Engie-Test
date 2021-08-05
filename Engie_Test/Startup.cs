using AutoMapper;
using Engie_Test.Entitites;
using Engie_Test.ViewModels;
using Engie_Test.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Engie_Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();           
            var autoMapperConfig = new AutoMapper.MapperConfiguration(cfg => {

                cfg.CreateMap<Provider, ProviderViewModels>().ReverseMap();
                cfg.CreateMap<PowerPlant, PowerPlantViewModels>().ReverseMap();

            });

            IMapper mapper = autoMapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<MainDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=PowerPlant}/{action=Index}/{id?}");
            });
        }
    }
}
