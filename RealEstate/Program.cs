using Application;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMvc();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddResponseCompression();


var app = builder.Build();
app.UseResponseCompression();
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Index}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();