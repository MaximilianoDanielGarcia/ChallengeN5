using AutoMapper;
using ChallengeN5.Context;
using ChallengeN5.Interfaces;
using ChallengeN5.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ChallengeN5.Models.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }); ;

builder.Services.AddDbContext<ChallengeN5Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IChallengeN5Context>(provider => provider.GetService<ChallengeN5Context>());

builder.Services.AddTransient<IPermisosService, PermisosService>();
builder.Services.AddTransient<ITipoPermisosService, TiposPermisoService>();

var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton(mapper);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    options.IgnoreObsoleteActions();
    options.IgnoreObsoleteProperties();
    options.EnableAnnotations();
    options.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
