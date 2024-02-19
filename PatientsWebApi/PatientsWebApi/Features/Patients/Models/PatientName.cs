using System;
using System.Collections.Generic;

namespace PatientsWebApi.Features.Patients.Models
{
    public partial class PatientName
    {
        public PatientName()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public bool Official { get; set; }
        public string? Family { get; set; }
        public string[]? Given { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
