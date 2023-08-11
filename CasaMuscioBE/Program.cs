using Microsoft.EntityFrameworkCore;
using CasaMuscioBENew.DAL.Context;
using System.Text.Json.Serialization;
using AutoMapper;
using CasaMuscioBE.API.Configuration;
using CasaMuscioBENew.DAL.IRepositories;
using CasaMuscioBENew.DAL.Entities;
using CasaMuscioBENew.BLL.IServices;
using CasaMuscioBENew.BLL.Services;
using CasaMuscioBENew.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
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
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRoomateService, RoomateService>();
builder.Services.AddScoped<IRoomateRepository, RoomateRepository>();



builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
var services = new ServiceCollection();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguration());
});
IMapper mapper = mapperConfig.CreateMapper();
services.AddSingleton(mapper);


builder.Services.AddCors(core =>
{
    core.AddPolicy("default", options =>
    {
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseCors("default");

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
