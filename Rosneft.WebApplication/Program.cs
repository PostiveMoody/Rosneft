using Microsoft.EntityFrameworkCore;
using Rosneft.DAL;
using Rosneft.WebApplication.Odata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RosneftDbContext>(options =>
    options.UseSqlServer(conn));

builder.Services.AddTransient<IConventionModelFactory, EdmModelFactory>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
