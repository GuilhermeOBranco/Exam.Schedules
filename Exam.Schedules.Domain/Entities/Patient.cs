using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Schedules.Domain.Entities
{
    public class Patient
    {
        public Guid PatientId { get; private set; }
        public string Name { get; private set; }

        public Patient(string name)
        {
            Name = name;
        }
    }
}