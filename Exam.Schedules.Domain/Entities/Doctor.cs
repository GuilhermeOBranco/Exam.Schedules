using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Schedules.Domain.Entities
{
    public class Doctor
    {
        public Guid DoctorId { get; private set; }

        public string Name { get; private set; }
        public Doctor(string name)
        {
            DoctorId = Guid.NewGuid();
            Name = name;
        }
    }
}