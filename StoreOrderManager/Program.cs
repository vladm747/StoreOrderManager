using StoreOrderManager.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplicationServices(builder.Configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.ConfigureMiddleware();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { controller = "Home", action = "Index" });

app.Run();