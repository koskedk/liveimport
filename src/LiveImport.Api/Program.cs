using LiveImport.Api;
using LiveImport.Core;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.Configure<BusSettings>(configuration.GetSection(BusSettings.Key));

var busSettings = builder.Configuration.GetSection(BusSettings.Key).Get<BusSettings>();

builder.Services.AddMassTransit(x =>
{
    x.AddSagaStateMachine<UploadStateMachine, UploadState>()
        .InMemoryRepository();
    x.UsingRabbitMq((context,cfg) =>
    {
        cfg.Host(busSettings.Host, busSettings.Vhost, h => {
            h.Username(busSettings.User);
            h.Password(busSettings.Pass);
        });

        cfg.ConfigureEndpoints(context);
    });
});

// Add services to the container.

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