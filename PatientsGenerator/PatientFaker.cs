using Bogus;

namespace PatientsGenerator;

public class PatientFaker : Faker<PatientModel>
{
	public PatientFaker()
    {
        RuleFor(d => d.IsOfficial, f => f.Random.Bool().ToString());
        RuleFor(d => d.GenderId, f => f.Random.Number(1, 4).ToString());
        RuleFor(d => d.BirthDate, f => f.Date.Between(new DateTime(1950, 1, 1), DateTime.Now).ToString("yyyy/MM/dd HH:mm:ss"));
        RuleFor(d => d.Family, f => f.Name.FirstName());
        RuleFor(d => d.Given, f => {
			string name1 = f.Name.FirstName();
			string name2 = " SomeSecName";
			return name1 + name2;
		});
    }
}
