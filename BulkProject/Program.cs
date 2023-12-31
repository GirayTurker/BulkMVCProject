using Bulk.DataAccess.Data;
using Bulk.DataAccess.Repository;
using Bulk.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationInsightsTelemetry();
//Add Entity Framework service and change dynamically connect to defined SQL server  
//builder.Services.AddDbContext<ApplicationDbContext>
//    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection1")));
//New Services registered for Repository  
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
//WILL REMOVE. ADDED FOR BEHAVIOR OBSERVATION
Console.WriteLine(".NET START");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //Area added to the route 
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
