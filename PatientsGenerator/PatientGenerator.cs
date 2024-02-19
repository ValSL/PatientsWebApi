using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatientsGenerator
{
    public class PatientGenerator
    {
        public List<PatientModel> GeneratePatients(int count)
        {
            var patients = new List<PatientModel>();
            for (int i = 0; i < count; i++)
            {
                patients.Add(new PatientFaker().Generate());
            }
            return patients;
        }
    }
}
