using OnlineShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'OnlineShopContextConnection' not found.");

//builder.Services.AddDbContext<OnlineShopContext>(options =>
  //  options.UseSqlServer(connectionString));

builder.Services.AddDbContext<OnlineShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<OnlineShopContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductTypesServices, ProductTypesServices>();
builder.Services.AddSingleton<ISpecialTagServices, SpecialTagServices>();
builder.Services.AddSingleton<IProductServices, ProductServices>();
builder.Services.AddSingleton<IHomeServices, HomeServices>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IOrderServices, OrderServices>();
builder.Services.AddSingleton<IApplicationUserServices, ApplicationUserServices>();
builder.Services.AddScoped<IRoleServices, RoleServices>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    //options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
;
