using MassTransit;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPVCalculation.Application.Base;
using NPVCalculation.Application.Consumers;
using NPVCalculation.Domain.Services;
using NPVCalculation.Infrastructure.Repository;
using Shared.ApiInfrastructure;
using Shared.Domain.Const;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationLayerBase).GetTypeInfo().Assembly));
builder.Services.AddScoped<INpvCalculationService, NpvCalculationService>();
builder.Services.AddScoped<INpvCalculationRepository, NpvCalculationRepository>();

builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}

// mongodb database
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDbSettings");
    return new MongoClient(settings["ConnectionString"]);
});

builder.Services.AddScoped(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDbSettings");
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings["DatabaseName"]);
});

// rabbitmq
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddConsumers(Assembly.GetAssembly(typeof(ApplicationLayerBase)));
    cfg.UsingRabbitMq((context, cfg) =>
    {
        var settings = builder.Configuration.GetSection("RabbitMqSettings");

        cfg.Host(settings["Host"], h =>
        {
            h.Username(settings["User"]);
            h.Password(settings["Password"]);
        });

        cfg.ReceiveEndpoint(RabbitMqQueues.NPV_CALCULATIONS_QUEUE_NAME, e =>
        {
            e.ConfigureConsumer<NpvCalculationTriggeredConsumer>(context);
        });
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Version = "v1",
        Title = "NPVCalculationAPI"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NPVCalculationAPI v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();

app.MapControllers();

app.Run();
