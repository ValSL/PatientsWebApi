using FluentValidation;

namespace PatientsWebApi.Features.Patients.UseCases.Commands.CreatePatient
{
    public interface ICreateCommandValidator : IValidator<IFormCollection>
    {
    }

    public class CreatePatientCommandValidator : AbstractValidator<IFormCollection>, ICreateCommandValidator
    {
        public CreatePatientCommandValidator()
        {
            RuleFor(x => x["BirthDate"].ToString()).NotEmpty().Matches(@"^\d{4}/\d{2}/\d{2} \d{2}:\d{2}:\d{2}$").WithMessage("Valid birthDate is required.");
            RuleFor(x => x["GenderId"].ToString()).NotEmpty().Matches(@"\d").WithMessage("Valid genderId is required.");
            RuleFor(x => x["IsOfficial"].ToString()).NotEmpty().Matches(@"^(true|false)$").WithMessage("Valid isOfficial is required.");
            RuleFor(x => x["Family"].ToString()).NotEmpty().Matches(@"^\D*$").WithMessage("Valid family is required.");
            RuleFor(x => x["Given"].ToString()).NotEmpty().Matches(@"^\D*$").WithMessage("Valid given is required.");
        }
    }
}
