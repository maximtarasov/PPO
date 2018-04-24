using Astral.Extensions.Hashing.MD5;
using CoffeePoint.Database;
using CoffeePoint.Domain;
using CoffeePoint.Domain.Entities;
using CoffeePoint.Domain.Services;
using CoffeePoint.Web.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeePoint.Web
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfigurationRoot Configuration { get; }
        
        public Startup(IHostingEnvironment env)
        {
            
            Environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMd5HashProvider();

            services.AddSession();
            services.AddMvc();
            services.AddIdentity<User, AccessPolicy>()
                .AddUserStore<IdentityStore>()
                .AddRoleStore<RoleStore>()
                .AddPasswordValidator<Md5PasswordValidator>()
                .AddDefaultTokenProviders();
            services.AddDatabase(Configuration["DatabaseConnections:DatabaseConnection"]);
            services.AddDomainServices();
            
            services.AddScoped<SessionContextProvider>();
            services.AddScoped(a => a.GetService<SessionContextProvider>().GetSessionContext());
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
            }

            
            app.UseSession();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authorization}/{action=Index}/{id?}");
            });
            
            app.ApplicationServices.GetService<DatabaseContext>().Database.Migrate();
            app.ApplicationServices.GetService<DataInitializationService>().SeedAll().Wait();
        }
    }
}