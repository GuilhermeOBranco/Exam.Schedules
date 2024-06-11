using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Schedules.Domain.Entities;
using Exam.Schedules.Domain.Repositories;
using MediatR;

namespace Exam.Schedules.Application.Commands.Handlers
{
    public class AppointmentCommandHandler : IRequestHandler<ScheduleAppointmentCommand, Guid>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentCommandHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Guid> Handle(ScheduleAppointmentCommand request, CancellationToken cancellationToken)
        {
            //Create patient and doctor to mock data
            var patient = new Patient(request.PatientName);
            var doctor  = new Doctor(request.DoctorName);

            var appointment = new Appointment(patient.PatientId, doctor.DoctorId, request.ScheduledStartDate, request.ScheduledEndDate);

            await _appointmentRepository.AddAsync(appointment);

            return appointment.Id;
        }
    }
}