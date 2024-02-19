using Microsoft.EntityFrameworkCore;
using PatientsWebApi.Features.Patients.Models;

namespace PatientsWebApi.Features.Patients.Repositories.GenderRepository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly PostgresContext _dbContext;
        public GenderRepository(PostgresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Gender> GetAllGenders()
        {
            IQueryable<Gender> genders = _dbContext.Genders.AsNoTracking();
            return genders;
        }
    }
}
