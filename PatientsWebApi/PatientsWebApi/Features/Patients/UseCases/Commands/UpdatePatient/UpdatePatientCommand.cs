using ErrorOr;
using MediatR;
using PatientsWebApi.Features.Patients.Contracts;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.UpdatePatient
{
    public record UpdatePatientCommand(int PatientId, DateTime BirthDate, int GenderId, bool IsOfficial, bool IsActive, string Family, string[] Given) : IRequest<ErrorOr<UpdatePatientResult>>;

}
