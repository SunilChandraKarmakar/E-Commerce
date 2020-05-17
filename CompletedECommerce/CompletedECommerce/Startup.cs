using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using CompletedECommerce.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CompletedECommerce.Manager.Contracts;
using CompletedECommerce.Manager;
using CompletedECommerce.Repository.Contracts;
using CompletedECommerce.Repository;

namespace CompletedECommerce
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
            });

            services.AddTransient<IAccountManager, AccountManager>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleManager, RoleManager>();
            services.AddTransient<IRoleAccountRepository, RoleAccountRepository>();
            services.AddTransient<IRoleAccountManager, RoleAccountManager>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISlideShowManager, SlideShowManager>();
            services.AddTransient<ISlideShowRepository, SlideShowRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductPhotoManager, ProductPhotoManager>();
            services.AddTransient<IProductPhotoRepository, ProductPhotoRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IInvoiceManager, InvoiceManager>();
            services.AddTransient<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
            services.AddTransient<IInvoiceDetailsManager, InvoiceDetailsManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
