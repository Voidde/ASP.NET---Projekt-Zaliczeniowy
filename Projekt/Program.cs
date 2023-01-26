using Microsoft.EntityFrameworkCore;
using Projekt.Models;
using Microsoft.AspNetCore.Identity;
using Projekt.Areas.Identity.Data;
using Microsoft.Extensions.Options;


namespace Projekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("IdentityAppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityAppDbContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Data:Connection"]));
            builder.Services.AddDbContext<IdentityAppDbContext>(options =>options.UseSqlServer(builder.Configuration["Data:AppIdentity:ConnectionString"]));


            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<IdentityAppDbContext>();

            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();;
            
            app.UseAuthorization();
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}