using PatientsWebApi.Features.Patients.Models;

namespace PatientsWebApi.Features.Patients.Repositories.GenderRepository
{
    public interface IGenderRepository
    {
        IQueryable<Gender> GetAllGenders();
    }
}