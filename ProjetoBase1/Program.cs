using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using ProjetoBase1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//public const string StringConnection = @"Data Source=DESKTOP-L7UFC1V;Initial Catalog=SGPAR;Integrated Security=True;Pooling=False; Connect Timeout=1200;";

builder.Services.AddDbContext<DataContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionLocal"));

    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();
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
//Liberar a API para não dar erro de CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
