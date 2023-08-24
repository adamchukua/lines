using Lines.Entities;
using Lines.Infrastructure;
using Lines.Infrastructure.Data;
using Lines.Services.ILikesService;
using Lines.Services.PostsService;
using Lines.Services.UsersService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddDbContext<LinesDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
builder.Services.AddIdentity<User, IdentityRole<long>>()
    .AddEntityFrameworkStores<LinesDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services
    .AddMvc()
    .AddDataAnnotationsLocalization();
builder.Services.AddScoped<IPostsService, PostsService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<ILikesService, LikesService>();

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

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
