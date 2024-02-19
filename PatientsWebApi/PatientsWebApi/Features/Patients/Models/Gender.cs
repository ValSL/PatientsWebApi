using System;
using System.Collections.Generic;

namespace PatientsWebApi.Features.Patients.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
