using Microsoft.EntityFrameworkCore;
using CasaMuscioBE.DAL.Context;
using System.Text.Json.Serialization;
using AutoMapper;
using CasaMuscioBE.API.Configuration;
using CasaMuscioBE.DAL.IRepositories;
using CasaMuscioBE.DAL.Entities;
using CasaMuscioBE.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(
      options => options.UseSqlite(
         builder.Configuration.GetConnectionString("DbConn")
      )
    );

var services = new ServiceCollection();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguration());
});
IMapper mapper = mapperConfig.CreateMapper();
services.AddSingleton(mapper);
services.AddScoped<AbstractRepository<Roomate>, RoomateRepository>();
services.AddScoped<IRoomateService, RoomateService>();


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
