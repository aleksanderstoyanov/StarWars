using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StarWarsApp.Data.Data;
using StarWarsApp.Data.Data.Seeders;
using StarWarsApp.Services.Services.Cache;
using StarWarsApp.Services.Services.CharacterMovies;
using StarWarsApp.Services.Services.Characters;
using StarWarsApp.Services.Services.Contracts;
using StarWarsApp.Services.Services.Movies;
using StarWarsApp.Services.Services.Vehicles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IMoviesService, MovieService>();
builder.Services.AddTransient<IVehicleService, VehicleService>();
builder.Services.AddTransient<ICharacterMovieService, CharacterMovieService>();
builder.Services.AddTransient<ICacheService, CacheService>();

var app = builder.Build();
var rootPath = builder.Environment.WebRootPath;

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    new MoviesSeeder().SeedAsync(dbContext, rootPath + @"\" + "movies.json").GetAwaiter().GetResult();
    new CharactersSeeder().SeedAsync(dbContext, rootPath + @"\" + "characters.json").GetAwaiter().GetResult();
    new VehiclesSeeder().SeedAsync(dbContext, rootPath + @"\" + "vehicles.json").GetAwaiter().GetResult();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.MapRazorPages();

app.Run();