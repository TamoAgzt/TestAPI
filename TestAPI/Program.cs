using Microsoft.EntityFrameworkCore;
using TestAPI.Contexts;
using TestAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(dbOptions =>
    dbOptions.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// CORS setup
builder.Services.SetupCorsAny();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowedOrigins");

// Use your custom database migration middleware
app.UseDatabaseMigration();

app.MapControllers();

app.Run();
