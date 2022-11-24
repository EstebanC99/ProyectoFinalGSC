using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using YouOweMe.Abstractions;
using YouOweMe.Logic;
using YouOweMe.Repositories;
using YouOweMe.Repositories.Users;
using YouOweMe.WebApi.Filter;
using YouOweMe.WebApi.Security;
using YouOweMe.WebApi.Security.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext

builder.Services.AddDbContext<YouOweMeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YouOweMeConnection"));
});

#endregion

#region Cors Enabling

builder.Services.AddCors();

#endregion

#region Repository Injections

builder.Services.AddScoped<IYouOweMeContext, YouOweMeContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region Logic Injections

builder.Services.AddScoped<IUserBusinessService, UserLogic>();

#endregion

#region Authorization Token

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtConfig"));

builder.Services.AddScoped<IJwtHandler, JwtHandler>();

#endregion

#region Filters

builder.Services.AddControllers(options =>
{
    options.Filters.Add<YouOweMeFilter>();
})
.AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

#endregion

#region App Build

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.Run();

#endregion