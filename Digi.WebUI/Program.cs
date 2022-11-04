using Digi.Core.Intefaces;
using Digi.Infra.CustomMiddleware;
using Digi.Infra.Interfaces;
using Digi.Infra.Persistence;
using Digi.Infra.Records.Maps;
using Digi.Infra.Repositories;
using Digi.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<DigiDbSettings>
    (builder.Configuration.GetSection("DigiDb"));

builder.Services.AddAutoMapper(typeof(DomainToRecordProfile));

builder.Services.AddScoped<IQueryTamer, QueryTamer>();
builder.Services.AddScoped<IQueryTamerService, QueryTamerService>();

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

app.UseRequestDatabase();

app.UseAuthorization();

app.MapControllers();

app.Run();


