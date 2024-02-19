using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PatientsWebApi.ErrorsList;
using PatientsWebApi.Features.Patients.Contracts;
using PatientsWebApi.Features.Patients.Models;
using PatientsWebApi.Features.Patients.Repositories.GenderRepository;
using PatientsWebApi.Features.Patients.Repositories.PatientRepository;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, ErrorOr<UpdatePatientResult>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IGenderRepository _genderRepository;
        
        public UpdatePatientCommandHandler(IPatientRepository patientRepository, IGenderRepository genderRepository)
        {
            _patientRepository = patientRepository;
            _genderRepository = genderRepository;
        }

        public async Task<ErrorOr<UpdatePatientResult>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patientResult = await _patientRepository.UpdatePatient(request);
            if(patientResult is null)
            {
                return Errors.PatientErrors.NotFound;
            }
            return new UpdatePatientResult(patientResult.Id);
        }
    }
}
