using AspNetCoreRateLimit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using MyFinances.API;
using MyFinances.API.Profiles;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Infra;
using MyFinances.Infra.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddOptions();

    // needed to store rate limit counters and ip rules
    builder.Services.AddMemoryCache();

    //load general configuration from appsettings.json
    builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

    //load ip rules from appsettings.json
    builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

    // inject counter and rules stores
    builder.Services.AddInMemoryRateLimiting();
    builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAd", options);

        options.TokenValidationParameters.NameClaimType = "name";
    },
    options => { builder.Configuration.Bind("AzureAd", options); });
}
else
{
    builder.Services.AddSwaggerGen();
}

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

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers().AllowAnonymous();
}
else
{
    app.UseIpRateLimiting();
    app.MapControllers();
}

app.UseCors();

app.Run();
