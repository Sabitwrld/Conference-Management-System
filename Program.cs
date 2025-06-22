using Conference_Management_System.Data;
using Conference_Management_System.Enums;
using Conference_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Conference_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            // Identity konfiqurasiyası
            // AddDefaultIdentity, AddIdentity-nin sadələşdirilmiş versiyasıdır.
            // AppUser custom olduğu üçün AddIdentity istifadə edirik
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // Şifrə tələbləri (təhlükəsizlik üçün)
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // İstifadəçi ayarları
                options.User.RequireUniqueEmail = true;

                // Giriş ayarları
                options.SignIn.RequireConfirmedAccount = false; // Email təsdiqini tələb etmir
            })
                .AddEntityFrameworkStores<AppDbContext>() // DbContext-i təyin edir
                .AddDefaultTokenProviders(); // Şifrə sıfırlama, email təsdiq kimi tokenlər üçün

            var app = builder.Build();



            // Configure the HTTP request pipeline.  
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
               name: "areas",
               pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();



            app.Run();
        }
    }
}
