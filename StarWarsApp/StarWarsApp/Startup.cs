namespace StarWarsApp
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using StarWarsApp.Data.Data;
    using StarWarsApp.Data.Data.Seeders;
    using StarWarsApp.Services.Services.Cache;
    using StarWarsApp.Services.Services.CharacterMovies;
    using StarWarsApp.Services.Services.Characters;
    using StarWarsApp.Services.Services.Movies;
    using StarWarsApp.Services.Services.Vehicles;

    public class Startup
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnectionString")));
            services.AddTransient<ICharacterService, CharacterService>();
            services.AddTransient<IMoviesService, MovieService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<ICharacterMovieService, CharacterMovieService>();
            services.AddTransient<ICacheService, CacheService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var rootPath = this.webHostEnvironment.WebRootPath;
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new MoviesSeeder().SeedAsync(dbContext, rootPath + @"\" + "movies.json").GetAwaiter().GetResult();
                new CharactersSeeder().SeedAsync(dbContext, rootPath + @"\" + "characters.json").GetAwaiter().GetResult();
                new VehiclesSeeder().SeedAsync(dbContext, rootPath + @"\" + "vehicles.json").GetAwaiter().GetResult();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
        }
    }
}
