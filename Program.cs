using FinancieraConsumo.Web.Components;
using FinancieraConsumo.Web.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SesionService>();



var app = builder.Build();
QuestPDF.Settings.License = LicenseType.Community;
app.MapGet("/api/recibo/{id}", async (int id, int? copias, ApplicationDbContext db) =>
{
    var cuota = await db.Cuotas.FindAsync(id);

    if (cuota == null)
        return Results.NotFound();
    var pdf = ReciboPagoPdf.Generar(cuota, copias ?? 1);

    return Results.File(pdf, "application/pdf", $"recibo_{id}.pdf");
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();