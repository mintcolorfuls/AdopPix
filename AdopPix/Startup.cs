using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.DataAccess.Data;
using AdopPix.Hubs;
using AdopPix.Models;
using AdopPix.Procedure;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopPix
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
            string connectionString = $"Server={Configuration["AWSMySQL_Server"]};Database={Configuration["AWSMySQL_Database"]};user={Configuration["AWSMySQL_Username"]};password={Configuration["AWSMySQL_Password"]}";

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/auth/Login";
                options.AccessDeniedPath = "/auth/AccessDenied";

                options.ExpireTimeSpan = TimeSpan.FromDays(1);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserProfileProcedure, UserProfileProcedure>();
            services.AddScoped<IPaymentLoggingProcedure, PaymentLoggingProcedure>();
            services.AddScoped<ISocialMediaProcedure, SocialMediaProcedure>();
            services.AddScoped<ISocialMediaTypeProcedure, SocialMediaTypeProcedure>();
            services.AddScoped<INotificationProcedure, NotificationProcedure>();
            services.AddScoped<IPostProcedure, PostProcedure>();

            //Register services
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ITokenPaymentService, TokenPaymentService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<INavbarService, NavbarService>();
            

            services.AddSignalR();

            services.AddRazorPages();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapRazorPages()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NotificationHub>("/hubs/notification");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
