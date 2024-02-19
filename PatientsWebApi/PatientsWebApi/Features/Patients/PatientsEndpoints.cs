using Carter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PatientsWebApi.ErrorsList;
using PatientsWebApi.Features.Patients.Contracts;
using PatientsWebApi.Features.Patients.Models;
using PatientsWebApi.Features.Patients.UseCases.Commands.CreatePatient;
using PatientsWebApi.Features.Patients.UseCases.Commands.DeletePatient;
using PatientsWebApi.Features.Patients.UseCases.Commands.UpdatePatient;
using PatientsWebApi.Features.Patients.UseCases.Queries;
using PatientsWebApi.Features.Patients.UseCases.Queries.GetAllPatients;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace PatientsWebApi.Features.Patients
{

    public class Test
    {
        public string A { get; set; }
    }

    public class PatientsEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/patients", GetAllPatients);
            app.MapPost("/api/patients", CreatePatient);
            app.MapMethods("/api/patients", new[] { "PATCH" }, UpdatePatient);
            app.MapDelete("/api/patients", DeletePatient);
        }

        public async Task<IResult> CreatePatient(HttpRequest request, IMediator mediator, ICreateCommandValidator validator)
        {
            var validationResult = await validator.ValidateAsync(request.Form);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var createProductCommand = new CreatePatientCommand(
                    DateTime.Parse(request.Form["BirthDate"]),
                    int.Parse(request.Form["GenderId"]),
                    bool.Parse(request.Form["IsOfficial"]),
                    request.Form["Family"],
                    request.Form["Given"].ToString().Split(',')
            );

            var getAllPatientsResult = await mediator.Send(createProductCommand);

            return getAllPatientsResult.Match(
                successResult => Results.Ok(successResult),
                errors => ProblemDetailsHelper.ProblemDetails(errors));
        }

        public async Task<IResult> GetAllPatients(IMediator mediator, [FromQuery] string? searchType, [FromQuery] DateTime? birthDate, [FromQuery] DateTime? birthDateTo)
        {
            var getAllPatientsQuery = new GetAllPatientsQuery(
               birthDateTo, birthDate, searchType);


            var getAllPatientsResult = await mediator.Send(getAllPatientsQuery);

            return getAllPatientsResult.Match(
                successResult => Results.Ok(successResult),
                errors => ProblemDetailsHelper.ProblemDetails(errors));
        }

        public async Task<IResult> UpdatePatient(HttpRequest request, IMediator mediator)
        {
            var updateProductCommand = new UpdatePatientCommand(
                    int.Parse(request.Form["PatientId"]),
                    DateTime.Parse(request.Form["BirthDate"]),
                    int.Parse(request.Form["GenderId"]),
                    bool.Parse(request.Form["IsOfficial"]),
                    bool.Parse(request.Form["IsActive"]),
                    request.Form["Family"],
                    request.Form["Given"].ToString().Split(',')
            );

            var updatePatientsResult = await mediator.Send(updateProductCommand);

            return updatePatientsResult.Match(
                successResult => Results.Ok(successResult),
                errors => ProblemDetailsHelper.ProblemDetails(errors));
        }

        public async Task<IResult> DeletePatient(HttpRequest request, IMediator mediator)
        {
            var deleteProductCommand = new DeletePatientCommand(
                    int.Parse(request.Form["Id"])
            );

            var deletePatientsResult = await mediator.Send(deleteProductCommand);

            return deletePatientsResult.Match(
                successResult => Results.Ok(successResult),
                errors => ProblemDetailsHelper.ProblemDetails(errors));
        }
    }
}
