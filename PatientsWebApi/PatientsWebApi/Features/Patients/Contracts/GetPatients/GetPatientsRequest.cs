using Microsoft.AspNetCore.Mvc;

namespace PatientsWebApi.Features.Patients.Contracts.GetPatients
{
    public class GetPatientsRequest
    {
        public string? SearchType { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? BirthDateTo { get; set; }
    }
}
