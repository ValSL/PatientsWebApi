using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PatientsWebApi.ErrorsList;
using PatientsWebApi.Features.Patients.Contracts.GetPatients;
using PatientsWebApi.Features.Patients.Models;
using PatientsWebApi.Features.Patients.Repositories.PatientRepository;
using PatientsWebApi.Features.Patients.UseCases.Queries.GetAllPatients;
using static PatientsWebApi.ErrorsList.Errors;

namespace PatientsWebApi.Features.Patients.UseCases.Queries.GetAllPatientsQeury
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, ErrorOr<GetAllPatientsResult>>
    {
        private readonly IPatientRepository _patientRepository;
        public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ErrorOr<GetAllPatientsResult>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            IQueryable<Patient>? patients = _patientRepository.GetAllPatients();

            if (patients is null)
            {
                return Errors.PatientErrors.FailToFetchPatients;
            }

            if (request.BirthDate.HasValue)
            {
                patients = request.SearchType switch
                {
                    "eq" => patients.Where(x => x.BirthDate == request.BirthDate),
                    "ne" => patients.Where(x => x.BirthDate != request.BirthDate),
                    "lt" => patients.Where(x => x.BirthDate < request.BirthDate),
                    "gt" => patients.Where(x => x.BirthDate > request.BirthDate),
                    "le" => patients.Where(x => x.BirthDate <= request.BirthDate),
                    "ge" => patients.Where(x => x.BirthDate >= request.BirthDate),
                };

                if (request.BirthDateTo.HasValue)
                {
                    patients = request.SearchType switch
                    {
                        "range" => patients.Where(x => x.BirthDate >= request.BirthDate && x.BirthDate <= request.BirthDateTo),
                    };
                }
            }

            return new GetAllPatientsResult(patients.ToList());
        }
    }
}
