using Microsoft.EntityFrameworkCore;
using MvcSeriesPersonajesDCC.Data;
using MvcSeriesPersonajesDCC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Creamos la conexion a la BBDD con builder.configuration y 
// agregamos el repository y el seriescontext para poder ser utilizado
string connectionString = builder.Configuration.GetConnectionString("SqlSeries");
builder.Services.AddTransient<RepositorySeries>();
builder.Services.AddDbContext<SeriesContext>(options => options.UseSqlServer(connectionString));

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

app.UseAuthorization();
//Modificamos  en Pattern el controller y la action para que al inicializar salga el listado
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Series}/{action=Index}/{id?}");

app.Run();
