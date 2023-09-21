using LaBook_Planet.Data.Context;
using LaBook_Planet.Data.Entities;
using LaBook_Planet.Library.Core.Services.Implementations;
using LaBook_Planet.Library.Core.Services.Implementations.ExternalServices;
using LaBook_Planet.Library.Core.Services.Interfaces;
using LaBook_Planet.Library.Core.Services.Interfaces.External;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);





builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanAdd", policy => policy.RequireClaim("CanAdd", new List<string> { "true" }));
    options.AddPolicy("CanEdit", policy => policy.RequireClaim("CanEdit", new List<string> { "true" }));
    options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete", new List<string> { "true" }));
});



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddDbContext<LaBook_PlanetContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<LaBook_PlanetContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddHttpClient();



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



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();