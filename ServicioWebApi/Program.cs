using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Formas de agregar servicios conexion con la DB.
string strConexion = builder.Configuration.GetSection("ConnectionStrings:CadenaActual").Value;
//string strConexion = builder.Configuration.GetConnectionString("CadenaActual");

//Registro el contexto
builder.Services.AddDbContext<NorthwindContext>(opcion => opcion.UseSqlServer(strConexion));
builder.Services.AddControllers();

// Se agrega Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
