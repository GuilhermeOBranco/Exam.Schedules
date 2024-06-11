using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Exam.Schedules.Application.Commands
{
    public class ScheduleAppointmentCommand : IRequest<Guid>
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }

        public ScheduleAppointmentCommand(string patientId, string doctorId, DateTime scheduledStartDate, DateTime scheduledEndDate)
        {
            PatientName = patientId;
            DoctorName = doctorId;
            ScheduledStartDate = scheduledStartDate;
            ScheduledEndDate = scheduledEndDate;
        }
    }
}