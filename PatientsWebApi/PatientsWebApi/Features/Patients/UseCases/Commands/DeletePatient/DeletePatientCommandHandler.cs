using ErrorOr;
using MediatR;
using PatientsWebApi.ErrorsList;
using PatientsWebApi.Features.Patients.Contracts;
using PatientsWebApi.Features.Patients.Repositories.GenderRepository;
using PatientsWebApi.Features.Patients.Repositories.PatientRepository;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.DeletePatient
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, ErrorOr<DeletePatientResult>>
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ErrorOr<DeletePatientResult>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var deletedPatient = await _patientRepository.DeleteProduct(request.Id);
            if(deletedPatient is null) 
            {
                return Errors.PatientErrors.NotFound;
            }
            return new DeletePatientResult(deletedPatient.Id);
        }
    }
}
