using Blazor_Laboration.Components;
using Blazor_Laboration.DbContexts;
using Blazor_Laboration.Interfaces;
using Blazor_Laboration.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BlazorConnection");
builder.Services.AddDbContext<BlazorContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddScoped<IBlazorRepository, BlazorRepository>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
