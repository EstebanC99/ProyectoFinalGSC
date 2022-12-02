using YouOweMe.Abstractions;
using YouOweMe.Entities.Factories.Interfaces;
using YouOweMe.Entities.Factories;
using YouOweMe.Repositories;
using YouOweMe.Repositories.Categories;
using YouOweMe.Repositories.Things;
using YouOweMe.Logic;
using YouOweMe.Logic.Mapper;
using Microsoft.EntityFrameworkCore;
using YouOweMe.MVC.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(cfg => cfg.Filters.Add(typeof(ExceptionManagerFilter)));
builder.Services.AddAutoMapper(typeof(HelperMapper));

#region DbContext

builder.Services.AddDbContext<YouOweMeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("YouOweMeConnection"));
});

#endregion

#region Factories

builder.Services.AddSingleton<ICategoryFactory, CategoryFactory>();
builder.Services.AddSingleton<IThingFactory, ThingFactory>();

#endregion

#region Cors Enabling

builder.Services.AddCors();

#endregion

#region Repository Injections

builder.Services.AddScoped<IYouOweMeContext, YouOweMeContext>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IThingRepository, ThingRepository>();

#endregion

#region Logic Injections

builder.Services.AddSingleton<IHelperMapper, HelperMapper>();
builder.Services.AddScoped<ICategoryBusinessService, CategoryLogic>();
builder.Services.AddScoped<IThingBusinessService, ThingLogic>();

#endregion

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
