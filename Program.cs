using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);//Создаёт экземпляр WebApplicationBuilder, который помогает настраивать приложение ASP.NET Core.

// Add services to the container.
builder.Services.AddRazorPages();//Добавляет поддержку Razor Pages, которые можно использовать для рендеринга страниц в приложении.
builder.Services.AddServerSideBlazor();//поддержку Blazor Server,

var app = builder.Build(); // представляет готовое к запуску приложение с настроенным сервером и маршрутизацией.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");//Настраивает централизованный обработчик ошибок,
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();//Включает HTTP Strict Transport Security (HSTS). Это механизм, который заставляет браузеры всегда использовать HTTPS для запросов. 
}

app.UseHttpsRedirection();//Перенаправляет все HTTP-запросы на HTTPS.

app.UseStaticFiles();//Позволяет приложению обслуживать статические файлы

app.UseRouting(); //В Blazor это используется для обработки навигации между страницами и компонентами.

app.MapBlazorHub();//Настраивает SignalR для Blazor Server приложения.
app.MapFallbackToPage("/_Host");//Настраивает приложение так, чтобы все запросы, которые не соответствуют статическим файлам или другим маршрутам, перенаправлялись на страницу /_Host

app.Run();
