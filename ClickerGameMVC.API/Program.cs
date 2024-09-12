using ClickerGameMVC.API;
using ClickerGameMVC.API.Controllers;
using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Business.Concrete;
using ClickerGameMVC.Common.MappingProfiles;
using ClickerGameMVC.Data;
using ClickerGameMVC.DataAccess.Data;
using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Models;
using ClickerGameMVC.Service.Abstract;
using ClickerGameMVC.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RoleClaimType = ClaimTypes.Role,
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:5240").AllowAnyMethod().AllowAnyHeader();
    }));


builder.Services.AddAutoMapper(typeof(UserMappingProfiles));
builder.Services.AddAutoMapper(typeof(ItemMappingProfiles));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IRepository<User>, EFRepository<User>>();
builder.Services.AddScoped<IRepository<Item>, EFRepository<Item>>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IService<User>, UserService>();
builder.Services.AddScoped<IService<Item>, ItemService>();
builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();


builder.Services.AddScoped<IAuthBusiness, AuthBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IItemBusiness, ItemBusiness>();
builder.Services.AddScoped<ILeaderboardBusiness, LeaderboardBusiness>();


builder.Services.AddScoped<AuthController>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<ItemController>();
builder.Services.AddScoped<LeaderboardController>();

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
    logging.SetMinimumLevel(LogLevel.Debug);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NgOrigins");

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseClaimsAnalyer();

app.UseAuthorization();

app.MapControllers();

app.UseSeedDb();

app.Run();