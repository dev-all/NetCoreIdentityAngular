
using allshop.api.Services;
using allshop.Mappers;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Identity;
using System;
using allshop.domain.Entities.Auth;
using allshop.api.Contracts.Services;
using allshop.Models.Common;
using allshop.repository.Context;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = builder.Configuration["AppSettings:CorsPolicy"];
var Client_URL = builder.Configuration["AppSettings:Client_URL"];
// Add services to the container.

builder.Services.AddControllers();

// Swagger/OpenApi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// configure DI for application services
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IRolesService, RolesService>();

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IGmailApiService, GmailApiService>();
//Inject AppSettings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


//Remove reference looping exception 
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var connectionString = builder.Configuration["connectionString:allshopConnectionString"];
//builder.Services.AddDbContext<allshopContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("allshop.api")));
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentityCore<AuthUser>()
              .AddRoles<AuthRole>()
              .AddEntityFrameworkStores<DatabaseContext>()
              .AddSignInManager()
              .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = IdentityConstants.ApplicationScheme;
//    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//});
////Authentication scheme spec
var key = Encoding.ASCII.GetBytes(builder.Configuration["AppSettings:Secret"]);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    // x.TokenValidationParameters = new TokenValidationParameters
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero,
    };
});



builder.Services.AddCors(options => {
    options.AddPolicy(name : myAllowSpecificOrigins,
        builder => {
            builder.WithOrigins(Client_URL)
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});


//---------------------------------------------------------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthentication();

app.MapControllers();

app.Run();

