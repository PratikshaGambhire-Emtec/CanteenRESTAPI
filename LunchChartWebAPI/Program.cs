using LunchChartWebAPI.Models;
using LunchChartWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MenuStoreDatabaseSettings>(
    builder.Configuration.GetSection("LunchMenuDatabase"));

builder.Services.AddSingleton<MenuService>();


builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
