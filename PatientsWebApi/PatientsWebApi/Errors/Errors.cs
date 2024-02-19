using ErrorOr;

namespace PatientsWebApi.ErrorsList
{
    public static class Errors
    {
        public static class PatientErrors
        {
            public static Error FailToFetchPatients = Error.Failure(code: "Patients.FailToFetch", description: "An error occurred while fetching data from database.");
            public static Error NotFound = Error.NotFound(code: "Patients.NotFound", description: "Patient with given parameters was not found.");
            public static Error InvalidSearchType = Error.Unexpected(code: "Patients.InvalidSearchType", description: "Invalid date search type");
        }
    }
}
