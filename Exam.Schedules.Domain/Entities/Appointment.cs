using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Schedules.Domain.Entities
{
    public class Appointment
    {
        public Guid Id { get; private set; }
        public Patient PatientId { get; private set; }
        public Doctor DoctorId { get; private set; }
        public DateTime ScheduledStartDate { get; private set; }
        public DateTime ScheduledEndDate { get; private set; }
        public bool IsCancelled { get; private set; }

        public Appointment(Patient patient, Doctor doctor, DateTime scheduledDate, DateTime scheduledEndDate)
        {
            if (!IsValidDatesAppointment(scheduledDate, scheduledEndDate))
            {
                throw new ArgumentException("Nao eh uma data valida para criacao de um agendamento");
            }

            Id = Guid.NewGuid();
            PatientId = patient;
            DoctorId = doctor;
            ScheduledStartDate = scheduledDate;
            ScheduledEndDate = scheduledEndDate;
            IsCancelled = false;
        }

        public void Cancel()
        {
            this.IsCancelled = true;
        }

        public bool IsValidDatesAppointment(DateTime start, DateTime end)
        {
            var duration = end - start;
            return duration.TotalHours >= 1 && duration.TotalHours <= 2;
        }

    }
}