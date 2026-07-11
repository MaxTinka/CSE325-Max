using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Data;
using MovieApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the database context with SQLite
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed the database with sample movies
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MovieContext>();
    
    // Only seed if the database is empty
    if (!context.Movie.Any())
    {
        context.Movie.AddRange(
            new Movie { Title = "The Matrix", ReleaseDate = new DateTime(1999, 3, 31), Genre = "Sci-Fi", Price = 14.99M, Rating = "9" },
            new Movie { Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16), Genre = "Action", Price = 12.99M, Rating = "8" },
            new Movie { Title = "The Godfather", ReleaseDate = new DateTime(1972, 3, 24), Genre = "Drama", Price = 9.99M, Rating = "10" },
            new Movie { Title = "Pulp Fiction", ReleaseDate = new DateTime(1994, 10, 14), Genre = "Crime", Price = 11.99M, Rating = "9" },
            new Movie { Title = "The Dark Knight", ReleaseDate = new DateTime(2008, 7, 18), Genre = "Action", Price = 13.99M, Rating = "9" }
        );
        context.SaveChanges();
    }
}

app.Run();