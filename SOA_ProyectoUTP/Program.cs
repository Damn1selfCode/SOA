using Microsoft.EntityFrameworkCore;
using SOA_ProyectoUTP.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UDEMYContext>(opt =>
{
	opt.UseSqlServer("Data Source=DAMN\\MSSQLSERVER2019;Initial Catalog=UDEMY;User ID=sa;Password=sql;Integrated Security=False;TrustServerCertificate=True;");
});

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
