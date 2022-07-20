
using BP.Ecommerce.API.Filters;
using Curso.ComercioElectronico.Application;
using Curso.ComercioElectronico.Application.ServicesImplementations;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Curso.ComercioElectronico.Infraestructure;
using Curso.ComercioElectronico.Infraestructure.Data;
using Curso.ComercioElectronico.Infraestructure.RepositoriesImplementations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ComercioElectronicoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddCors();

builder.Services.AddControllers(options =>
{
    //Aplicar filter globalmente a todos los controller
    options.Filters.Add<ApiExceptionFilterAttribute>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // Permitir cualquier origen
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
