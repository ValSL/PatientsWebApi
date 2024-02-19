using MediatR;
using Microsoft.EntityFrameworkCore;
using PatientsWebApi.ErrorsList;
using PatientsWebApi.Features.Patients.Models;
using PatientsWebApi.Features.Patients.UseCases.Commands.UpdatePatient;

namespace PatientsWebApi.Features.Patients.Repositories.PatientRepository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PostgresContext _dbContext;
        public PatientRepository(PostgresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePatient(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Patient> GetAllPatients()
        {
            IQueryable<Patient> patients = _dbContext.Patients.Include(x => x.Name).Include(x => x.Gender).AsNoTracking();
            return patients;
        }

        public async Task<Patient?> UpdatePatient(UpdatePatientCommand request)
        {
            IQueryable<Patient> patients = _dbContext.Patients.Include(x => x.Name);
            Patient? searchedPatient = patients.Where(x => x.Id == request.PatientId).SingleOrDefault();
            if (searchedPatient is not null)
            {
                searchedPatient.Name.Family = request.Family;
                searchedPatient.Name.Official = request.IsOfficial;
                searchedPatient.Name.Given = request.Given;
                searchedPatient.GenderId = request.GenderId;
                searchedPatient.BirthDate = request.BirthDate;
                searchedPatient.Active = request.IsActive;
                await _dbContext.SaveChangesAsync();
            }
            return searchedPatient;
        }

        public async Task<Patient?> DeleteProduct(int id)
        {
            Patient? patient = _dbContext.Patients.Find(id);
            if (patient is not null)
            {
                _dbContext.Patients.Remove(patient);
                await _dbContext.SaveChangesAsync();
            }
            return patient;
        }
    }
}
