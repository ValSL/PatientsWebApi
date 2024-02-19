using ErrorOr;
using MediatR;
using PatientsWebApi.Features.Patients.Contracts;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.DeletePatient
{
    public record DeletePatientCommand(int Id) : IRequest<ErrorOr<DeletePatientResult>>;
}
