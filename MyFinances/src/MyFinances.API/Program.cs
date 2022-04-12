using MediatR;
using Microsoft.EntityFrameworkCore;
using MyFinances.API;
using MyFinances.API.Profiles;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Infra;
using MyFinances.Infra.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(cfg => cfg.LowercaseUrls = true);

builder.Services.AddLogging();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

string connectionString = builder.Configuration.GetConnectionString("MYFINANCES_DB");

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.Create(new Version("8.0.21"), Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql)));

builder.Services.AddAutoMapper(cfg => cfg.CreateMap<DateOnly, DateTime>().ConvertUsing(s => s.ToDateTime(TimeOnly.MinValue)));
builder.Services.AddAutoMapper(typeof(TransactionProfile).Assembly);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.AddSwaggerGen();

string blazorUrl = builder.Configuration.GetValue<string>("BLAZOR_URL") ?? "*";

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins(blazorUrl);
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
