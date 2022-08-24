using WebApplication11.Core.Configuration;
using WebApplication11.Core.Interfaces;
using WebApplication11.Core.Services;
using WebApplication11.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDataProvide, DataProvider>();

builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.Configure<DataProviderOptions>(
    builder.Configuration.GetSection("DataProviderOptions"));

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