using ErrorOr;
using MediatR;
using PatientsWebApi.Features.Patients.Contracts;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.CreatePatient
{
    public record CreatePatientCommand(DateTime BirthDate, int GenderId, bool IsOfficial, string Family, string[] Given) : IRequest<ErrorOr<CreatePatientResult>>;
}
