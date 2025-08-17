using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);//������ ��������� WebApplicationBuilder, ������� �������� ����������� ���������� ASP.NET Core.

// Add services to the container.
builder.Services.AddRazorPages();//��������� ��������� Razor Pages, ������� ����� ������������ ��� ���������� ������� � ����������.
builder.Services.AddServerSideBlazor();//��������� Blazor Server,

var app = builder.Build(); // ������������ ������� � ������� ���������� � ����������� �������� � ��������������.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");//����������� ���������������� ���������� ������,
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();//�������� HTTP Strict Transport Security (HSTS). ��� ��������, ������� ���������� �������� ������ ������������ HTTPS ��� ��������. 
}

app.UseHttpsRedirection();//�������������� ��� HTTP-������� �� HTTPS.

app.UseStaticFiles();//��������� ���������� ����������� ����������� �����

app.UseRouting(); //� Blazor ��� ������������ ��� ��������� ��������� ����� ���������� � ������������.

app.MapBlazorHub();//����������� SignalR ��� Blazor Server ����������.
app.MapFallbackToPage("/_Host");//����������� ���������� ���, ����� ��� �������, ������� �� ������������� ����������� ������ ��� ������ ���������, ���������������� �� �������� /_Host

app.Run();
