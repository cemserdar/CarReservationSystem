using Microsoft.EntityFrameworkCore;
using CarReservationSystem.Infrastructure.Data;
using CarReservationSystem.Domain.Repositories;
using CarReservationSystem.Infrastructure.Repositories;
using CarReservationSystem.Domain.Services;
using CarReservationSystem.Application.Services;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// SQLite başlatma
Batteries.Init();

// SQLite veritabanı bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

// Repository'leri register et
builder.Services.AddScoped<ICarRepository, CarRepository>();

// Servisleri register et
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Veritabanını otomatik olarak oluştur (Development ortamında)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // Veritabanını oluşturur (eğer yoksa)
}

app.Run();