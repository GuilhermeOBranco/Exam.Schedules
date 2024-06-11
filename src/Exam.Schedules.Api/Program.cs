using Exam.Schedule.Infrastructure.Data;
using Exam.Schedules.Application.Commands.Handlers;
using Exam.Schedules.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exam.Schedule API", Version = "v1" });
    // Configurações adicionais do Swagger, se necessário
});

// Add in-memory database
builder.Services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("DatabaseDefault"));

// Add DI
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(typeof(AppointmentCommandHandler).Assembly);
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exam.Schedule API v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
