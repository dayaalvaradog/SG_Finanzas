using _2_SGF_Modelo;
using _3_SGF_AccesoDatos;
using _5_SGF_Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;

string MiCors = "SGFCors";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
                      builder =>
                      {
                          builder.WithOrigins("*");
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<SGFContext>();
builder.Services.AddScoped<ICatalogo, ADCatalogo>();
builder.Services.AddScoped<ILogin, ADLogin>();
builder.Services.AddScoped<IMantenimiento, ADMantenimiento>();
builder.Services.AddScoped<IMovimiento, ADMovimiento>();
builder.Services.AddScoped<ICuenta, ADCuenta>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();

