using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle;
using Microsoft.OpenApi.Models;
using BmesRestApi.Repositories.Implementations;
using BmesRestApi.Repositories;
using BmesRestApi.Services;
using BmesRestApi.Services.Implementations;
using Microsoft.AspNetCore.Http;
using BmesRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity;
using BmesRestApi.Infrastructure;
using BmesRestApi.Database;

namespace BmesRestApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Bmes Api Core", Description = "It is a WEB Store (Back-end)", Version = "v1" });
               c.AddSecurityDefinition(name: "Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme{
                       Reference = new OpenApiReference
                       {
                         Id= "Bearer",
                         Type = ReferenceType.SecurityScheme
                       }
                     },new List<string>()
                   }                   
                });
            });
            services.AddMemoryCache();
            services.AddSession();
            services.AddDistributedMemoryCache();

            services.AddDbContext<Database.BmesDbContext>(optionsAction: options => options.UseSqlite(Configuration["Data:BmesApi:ConnectionString"]));
            services.AddDbContext<Database.BmesIdentityDbContext>(option => option.UseSqlite(Configuration["Data:BmesIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<Database.BmesIdentityDbContext>();

            services.AddJwtAuth(Configuration);

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICartItemRepository, CartItmeRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IAddressRespository, AddressRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPersonRepositery, PersonResository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICheckoutService, CheckoutService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICatalogueService, CatalogueService>();
            services.AddTransient<ICartService, CartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            { 
                c.SwaggerEndpoint(url:"/swagger/v1/swagger.json", name:"Bmes Api Core"); 
            });
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Create a service scope to get an BmesIdntityDbContext instace using DI
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<BmesIdentityDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                //Create the Db if it does not exist and applies any panding migration.
                //dbContext.Database.Migrate();

                IdentityDbSeeder.Seed(dbContext, roleManager, userManager);

            }
        }
    }
}
