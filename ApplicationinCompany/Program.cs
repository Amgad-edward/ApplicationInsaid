using ApplicationinCompany;
using ApplicationinCompany.Data;
using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using TheModels;
using TheModels.InterfaceUnitWork;
using TheModels.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddBlazoredSessionStorage(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddBlazoredToast();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSession(session =>
{
    session.Cookie.IsEssential = true;
});



builder.Services.AddBlazoredToast();

builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 102400000;
   
});

builder.Services.AddDbContext<ContextApplication>(options =>
{
      options.UseMySql(builder.Configuration.GetConnectionString("db"),
       new MariaDbServerVersion(new Version()),
       m => m.MigrationsAssembly("ApplicationinCompany"));
      
      options.EnableSensitiveDataLogging();
},    ServiceLifetime.Transient, ServiceLifetime.Transient);

if(Hex.Connections == "")
{
    Hex.Connections = builder.Configuration.GetConnectionString("db");
}

builder.Services.AddTransient<IUntiWork, UntiWork<ContextApplication>>();


builder.Services.Configure<JsonSerializerOptions>(builder =>
{
    builder.Converters.Add(new DateConvertJosndateoly());
    builder.AllowTrailingCommas = true;
});
builder.Services.Configure<JsonSerializerOptions>(builder =>
{
    builder.Converters.Add(new DateConvertJosnTimeonly());
    builder.AllowTrailingCommas = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseRouting();

app.UseSession();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
