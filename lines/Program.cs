using Lines.Entities;
using Lines.Infrastructure;
using Lines.Infrastructure.Data;
using Lines.Services.PostsService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<LinesDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole<long>>()
    .AddEntityFrameworkStores<LinesDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPostsService, PostsService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LinesDbContext>();
    await context.Database.EnsureCreatedAsync();
    DataSeeder.SeedData(context);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
