using Microsoft.EntityFrameworkCore;
using One_Stop_Solution.Data;
using Microsoft.AspNetCore.Identity;
using One_Stop_Solution.Repositories;
using One_Stop_Solution.Areas.Identity.Data;

//using One_Stop_Solution.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<IEndUserRepository, EndUserRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddDefaultIdentity<fyp_SolutionUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();




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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

//// Define Routing
///

//app.MapControllerRoute(
//    name: "category",
//    pattern: "{controller=Categories}/{action=ShowAllCategories}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Main}/{id?}");

app.Run();
