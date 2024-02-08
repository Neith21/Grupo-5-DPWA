using FluentValidation;
using G5Inventory.Models;
using G5Inventory.Validations;
using G5Inventory.Validatios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IValidator<ProductModel>, ProductValidator>();
builder.Services.AddScoped<IValidator<CategoryModel>, CategoryValidator>();
<<<<<<< HEAD
=======
builder.Services.AddScoped<IValidator<ProviderModel>, ProviderValidator>();
>>>>>>> 6e33593 (Parte de Carlos)

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
