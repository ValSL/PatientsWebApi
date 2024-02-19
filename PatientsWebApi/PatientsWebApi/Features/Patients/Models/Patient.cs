using System;
using System.Collections.Generic;

namespace PatientsWebApi.Features.Patients.Models
{
    public partial class Patient
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

        public virtual Gender Gender { get; set; } = null!;
        public virtual PatientName Name { get; set; } = null!;
    }
}
