using FluentValidation;
using PatientsWebApi.Features.Patients.Repositories.GenderRepository;
using PatientsWebApi.Features.Patients.Repositories.PatientRepository;
using PatientsWebApi.Features.Patients.UseCases.Commands.CreatePatient;

namespace PatientsWebApi.Features.Patients
{
   

    public static class Setup
    {
        public static IServiceCollection AddPatientsFeatures(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPatientRepository, PatientRepository>();
            serviceCollection.AddScoped<IGenderRepository, GenderRepository>();
            serviceCollection.AddScoped<ICreateCommandValidator, CreatePatientCommandValidator>();

            return serviceCollection;
        }
    }
}
