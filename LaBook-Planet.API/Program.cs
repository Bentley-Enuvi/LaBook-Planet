using LaBook_Planet.API.Library.Domain.Context;
using LaBook_Planet.API.Library.Domain.Models;
using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.Repositories;
using Library.API.Extensions;
using Library.API.Middlewares;
using Library.Core.Interfaces.Services;
using Library.Core.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.VisualStudio.Services.Aad;
using NLog;
using NLog.Web;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();



builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();



// swagger documentation setup
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Fast api",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{}
            }
        });
});



builder.Services.AddDbContext<LaBookContextApi>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanAdd", policy => policy.RequireClaim("CanAdd", new List<string> { "true" }));
    options.AddPolicy("CanEdit", policy => policy.RequireClaim("CanEdit", new List<string> { "true" }));
    options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete", new List<string> { "true" }));
});



builder.Services.AddAutoMapper(typeof(LaBookProfile));



var app = builder.Build();

builder.Logging.AddConsole();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseRouting();


//app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();

//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//logger.Debug("init main");


//try
//{
//    var builder = WebApplication.CreateBuilder(args);

//    // Add services to the container.
//    builder.Services.AddControllers();
//    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//    builder.Services.AddEndpointsApiExplorer();

//    // swagger documentation setup
//    builder.Services.AddSwaggerGen(options =>
//    {
//        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
//        {
//            Description = "Fast api",
//            Name = "Authorization",
//            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
//            BearerFormat = "JWT",
//            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
//            Scheme = "Bearer"
//        });
//        options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
//        {
//            {
//                new OpenApiSecurityScheme
//                {
//                    Reference = new OpenApiReference
//                    {
//                        Type = ReferenceType.SecurityScheme,
//                        Id = "Bearer"
//                    }
//                },
//                new string[]{}
//            }
//        });
//    });

//    var connStr = builder.Configuration.GetSection("ConnectionStrings:default").Value;
//    //var connStr = builder.Configuration.GetConnectionString("default");
//    builder.Services.AddDbContext<LaBookContextApi>(options =>
//    {
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//        options.EnableSensitiveDataLogging();
//    });


//    //builder.Services.AddScoped<IBookRepository, BookRepository>();
//    builder.Services.AddScoped<IBookService, BookService>();


//    // authentication scheme setup
//    builder.Services.AddAuthentication(options =>
//    {
//        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    }).AddJwtBearer(options =>
//    {
//        var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:Key").Value);
//        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(key),
//            ValidateLifetime = true,
//            ValidateAudience = false,
//            ValidateIssuer = false
//        };

//    });

//    //builder.Services.AddIdentity<Book, IdentityRole>(options =>
//    //{
//    //    //options.Password.RequiredUniqueChars = 0;
//    //    //options.Password.RequireNonAlphanumeric = false;
//    //})
//    //    .AddEntityFrameworkStores<LaBookContextApi>();
//    //// UserManager
//    //// RoleManager
//    //// SignInManager

//    builder.Services.AddAuthorization(options =>
//    {
//        options.AddPolicy("CanAdd", policy => policy.RequireClaim("CanAdd", new List<string> { "true" }));
//        options.AddPolicy("CanEdit", policy => policy.RequireClaim("CanEdit", new List<string> { "true" }));
//        options.AddPolicy("CanDelete", policy => policy.RequireClaim("CanDelete", new List<string> { "true" }));
//    });

//    builder.Services.AddAutoMapper(typeof(Program));


//    var app = builder.Build();

//    builder.Logging.AddConsole();

//    // Configure the HTTP request pipeline.
//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI(); // setupAction => { setupAction.SwaggerEndpoint("/swagger/LaBook-Planet.API/swagger.json", "LaBook-Planet API"); });
//    }

//    app.UseHttpsRedirection();

//    app.UseAuthentication();
//    app.UseAuthorization();

//    app.MapControllers();

//    app.Run();
//}
//catch (Exception exception)
//{ 
//    logger.Error(exception, "Stopped program because of exception");
//throw;
//}
//finally
//{
//    NLog.LogManager.Shutdown();
//}

