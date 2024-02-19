using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using PatientsWebApi.Features.Patients;
using PatientsWebApi.Features.Patients.Models;
using PatientsWebApi.Features.Patients.UseCases.Commands.CreatePatient;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPatientsFeatures();
builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts => opts.EnableAnnotations());
builder.Services.AddDbContext<PostgresContext>();
builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    app.UseExceptionHandler("/error");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();


    app.MapCarter();
    app.Run();
}
