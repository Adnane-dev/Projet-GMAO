using GMAO.Models.Connection;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Utilisez la clé de connexion correcte

builder.Services.AddDbContext<GMAOContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();


// Ajoutez la configuration CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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

app.UseHttpsRedirection();

// Utilisez CORS avant UseAuthorization et MapControllers
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
