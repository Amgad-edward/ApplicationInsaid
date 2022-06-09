using Microsoft.AspNetCore.Components;
using TheModels;
using TheModels.Models;
using TheModels.InterfaceUnitWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(session =>
{
    session.Cookie.IsEssential = true;
});
builder.Services.AddDbContext<ContextApplication>(option =>
{
    option.UseMySql(builder.Configuration.GetConnectionString("dbconnect") , new MariaDbServerVersion(new Version()));

});

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

builder.Services.AddMvc(s => s.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
    .AddNewtonsoftJson(js => js.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapBlazorHub();
});



app.Run();
