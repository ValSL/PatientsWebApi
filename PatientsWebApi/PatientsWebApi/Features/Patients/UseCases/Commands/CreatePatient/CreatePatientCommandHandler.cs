using ErrorOr;
using MediatR;
using PatientsWebApi.Features.Patients.Contracts;
using PatientsWebApi.Features.Patients.Models;
using System.Security.Cryptography.Xml;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, ErrorOr<CreatePatientResult>>
    {
        private readonly PostgresContext _context;
        public CreatePatientCommandHandler(PostgresContext context)
        {
            _context = context;
        }
        public async Task<ErrorOr<CreatePatientResult>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Gender gender = _context.Genders.Single(item => item.Id == request.GenderId);

            PatientName patientName = new PatientName
            {
                Official = request.IsOfficial,
                Family = request.Family,
                Given = request.Given,
            };

            Patient patient = new Patient
            {
                Name = patientName,
                Gender = gender,
                BirthDate = request.BirthDate.ToUniversalTime(),
                Active = true
            };

            await _context.Patients.AddAsync(patient, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreatePatientResult(patient.Id);
        }
    }
}
