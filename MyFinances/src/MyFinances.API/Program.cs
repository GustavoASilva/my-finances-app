using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using MyFinances.API;
using MyFinances.API.HostedServices;
using MyFinances.API.Profiles;
using MyFinances.API.Services;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Infra;
using MyFinances.Infra.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<RecurrentTransactionService>();
builder.Services.AddLogging();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IRecurrenceService, RecurrenceService>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql("Server=host.docker.internal; Port=3306; Database=MyFinances; Uid=root; Pwd=Gg@03102020;", ServerVersion.Create(new Version("8.0.28"), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql)));

builder.Services.AddAutoMapper(typeof(TransactionProfile));
builder.Services.AddAutoMapper(typeof(OriginProfile));

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
}));

var assemblies = new Assembly[]
      {
        typeof(AppDbContext).Assembly,
        typeof(Recurrence).Assembly
      };

builder.Services.AddMediatR(assemblies);

var app = builder.Build();

app.MigrateDatabase<AppDbContext>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
