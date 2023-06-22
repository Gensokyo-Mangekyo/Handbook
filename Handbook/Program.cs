using Handbook.Models;
using Handbook.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // добавляем сервисы MVC
builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddTransient<ArticleService>();
builder.Services.AddTransient<SearchService>();

var app = builder.Build();
app.UseStaticFiles();


// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
