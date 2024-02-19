using PatientsGenerator;

const string baseUrl = "https://localhost:8898/api/patients";
var client = new PatientApiClient(baseUrl);
var generator = new PatientGenerator();

const int numberOfPatientsToAdd = 100;
var patients = generator.GeneratePatients(numberOfPatientsToAdd);

foreach (var patient in patients)
{
    await client.AddPatientAsync(patient);
}

Console.WriteLine($"Added {numberOfPatientsToAdd} patients.");
