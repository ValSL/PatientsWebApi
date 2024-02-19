using ErrorOr;
using MediatR;
using PatientsWebApi.Features.Patients.Contracts.GetPatients;

namespace PatientsWebApi.Features.Patients.UseCases.Queries.GetAllPatients
{
    public record GetAllPatientsQuery(DateTimeOffset? BirthDateTo, DateTimeOffset? BirthDate, string? SearchType) : IRequest<ErrorOr<GetAllPatientsResult>>;
}
