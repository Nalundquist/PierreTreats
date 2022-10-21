using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PierreTreats.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace PierreTreats
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddEntityFrameworkMySql()
        .AddDbContext<PierreTreatsContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));

      services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<PierreTreatsContext>()
              .AddDefaultTokenProviders();

			services.AddDefaultIdentity<ApplicationUser>()
							.AddRoles<IdentityRole>()
							.AddEntityFrameworkStores<DbContext>();

			services.AddAuthorization(options =>
			{
				options.FallbackPolicy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
			});

			services.Configure<IdentityOptions>(options =>
    	{
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 0;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredUniqueChars = 0;
    	});
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();

      app.UseAuthentication();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });

      app.UseStaticFiles();
      
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }

		public async Task CreateRoles(IServiceProvider serviceProvider)
		{
			var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			string[] roleNames = { "Admin", "User" }
			IdentityResult roleResult;

			foreach (var roleName in roleNames)
			{
				var roleExist = await RoleManager.RoleExistsAsync(roleName);
				if (!roleExist)
				{
					roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName))
				}
			}
			var adminPierre = new ApplicationUser
			{
				UserName = "PierreIsBest"
				Email = "PierreBiencoupe1972@fake.com"
				FirstName = "Pierre"
				LastName = "Biencoupe"
				FavFood = "Baguette"
			};
			string pierrePass = "3cL@1r";
			var _user = await UserManager.FindByEmailAsync("PierreBiencoupe1972@fake.com")

			if(_user == null)
			{
				var createAdmin = await UserManager.CreateAsync(adminPierre, pierrePass);
				if (createAdmin.Succeeded)
				{
					await UserManager.AddToRoleAsync(adminPierre, "Admin");
				}
			}
		}
  }
}