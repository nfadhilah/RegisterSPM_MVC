using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RegisterSPM.DataAccess;
using RegisterSPM.DataAccess.Data;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Filters;
using RegisterSPM.Utility;

namespace RegisterSPM
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
      services.AddDatabaseDeveloperPageExceptionFilter();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
          options.SignIn.RequireConfirmedAccount = false;
          options.Password.RequireDigit = false;
          options.Password.RequireLowercase = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireUppercase = false;
        })
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<ApplicationDbContext>();

      services.ConfigureApplicationCookie(options =>
      {
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
      });

      services.AddRazorPages();

      services.AddScoped<IStoreProcedureCall>(provider =>
      {
        var context = provider.GetService<IHttpContextAccessor>()?.HttpContext;
        var year = context?.Session.GetObject<string>(SD.SsTahun);
        var host = Configuration.GetConnectionString("SIPKDConnection");

        return int.TryParse(year, out var dbYear)
          ? new StoreProcedureCall(Configuration.SetDbYear(host, dbYear))
          : new StoreProcedureCall(host);
      });

      services.AddControllersWithViews(config => { config.Filters.Add(new SessionExpirationFilter()); });
      services.AddSession(options =>
      {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
      });

      services.AddAutoMapper(nameof(Startup).GetType().Assembly);

      services.AddHttpClient();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseStatusCodePagesWithRedirects("/Main/Error?code={0}");
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseSession();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area=Main}/{controller=SPM}/{action=Index}/{id?}"
        );
      });

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