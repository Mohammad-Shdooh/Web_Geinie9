using Microsoft.EntityFrameworkCore;
using Web_Geinie9.Models;
using Web_Geinie9.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddScoped<SignUp>();
builder.Services.AddScoped<LogIn>();
builder.Services.AddDbContext<Geinie9Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Gienie9"));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
