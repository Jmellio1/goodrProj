using goodrProj.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DataAccessLibrary;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using DataAccessLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
//using goodrProj.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Users");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IAPIcall, APIcall>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ISqlAccess, SqlAccess>();
builder.Services.AddTransient<IEmployeeData, EmployeeData>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddMvc(setupAction: options => options.EnableEndpointRouting = false)
    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
builder.Services.AddDbContext<goodrProjContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("goodrProjContext")));


builder.Services.AddControllers(options =>
{
    options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzE1MDAxQDMxMzgyZTMyMmUzMGZaYkdYWFNwWlhVS1Vva29NVWdtcCtKNllBNXNpRkhPTFBIOEhiaGxPS2s9");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMvcWithDefaultRoute();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
