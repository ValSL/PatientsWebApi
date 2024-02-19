using PatientsWebApi.Features.Patients.Models;
using PatientsWebApi.Features.Patients.UseCases.Commands.UpdatePatient;

namespace PatientsWebApi.Features.Patients.Repositories.PatientRepository
{
    public interface IPatientRepository
    {
        Task CreatePatient(Patient patient);
        Task<Patient?> DeleteProduct(int id);
        IQueryable<Patient> GetAllPatients();
        Task<Patient?> UpdatePatient(UpdatePatientCommand request);
    }
}