using manager.Context;
using manager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options => options.UseMySql(
    "server=localhost;initial catalog=STOCK_MANAGER; uid=root;pwd=15101981", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ProductTypeService>();
builder.Services.AddScoped<ProductSizeService>();
builder.Services.AddScoped<ProductService>();



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
