using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FineWoodworkingBasic.Util;
using FineWoodworkingBasic.Service;
using FineWoodworkingBasic.Service;

var builder = WebApplication.CreateBuilder(args);

Utilities.EstablishConnection("C:\\Users\\Sweet Baby Jay\\source\\repos\\FineWoodworkingBasic\\FineWoodworkingBasic\\dbConfig.ini");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Register the login service
builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<AddBrandService>();
// Add the AppState class
builder.Services.AddScoped<AllStateInfoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
