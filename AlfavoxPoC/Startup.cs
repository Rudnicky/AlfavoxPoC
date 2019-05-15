using AlfavoxPoC.Core.Interfaces;
using AlfavoxPoC.Persistence;
using AlfavoxPoC.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AlfavoxPoC
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // registering StarWarsDbContext
            services.AddDbContext<AlfavoxDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // swagger generator
            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new Info() { Title = "Companies Api", Version = "v1" }));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<ICompanyEmployeeRepository, CompanyEmployeeRepository>();
            services.AddScoped<ICompanyLocationRepository, CompanyLocationRepository>();
            services.AddScoped<ICompanyProductRepository, CompanyProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSwagger();
            app.UseSwaggerUi(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Api for Companies"));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
