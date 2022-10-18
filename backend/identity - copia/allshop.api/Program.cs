using allshop.api.Services.Contracts;
using allshop.api.Services;
using allshop.Mappers;
using allshop.repository.Context;
using allshop.repository.Contracts;
using allshop.repository.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var myAllowSpecificOrigins = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRolesService, RolesService>();

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IGmailApiService, GmailApiService>();


//Remove reference looping exception 
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var connectionString = builder.Configuration["connectionString:allshopConnectionString"];
//builder.Services.AddDbContext<allshopContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("allshop.api")));
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options => {
    options.AddPolicy(name : myAllowSpecificOrigins,
        builder => {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

//Authentication scheme spec
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
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = System.TimeSpan.Zero,
    };
});

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

