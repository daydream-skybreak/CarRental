var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env
DotNetEnv.Env.Load();

// Build PostgreSQL connection string from environment variables
string? dbUser = Environment.GetEnvironmentVariable("DB_USER");
string? dbEmail = Environment.GetEnvironmentVariable("DB_EMAIL"); // Not used in connection string, but available
string? dbHost = Environment.GetEnvironmentVariable("DB_HOST");
string? dbName = Environment.GetEnvironmentVariable("DB_NAME");
string? dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
string dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";

string postgresConnection = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

builder.Configuration["ConnectionStrings:DefaultConnection"] = postgresConnection;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();