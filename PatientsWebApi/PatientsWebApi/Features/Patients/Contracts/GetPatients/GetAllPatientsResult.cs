using PatientsWebApi.Features.Patients.Models;

namespace PatientsWebApi.Features.Patients.Contracts.GetPatients
{
    public record GetAllPatientsResult(List<Patient> Patients);
}
