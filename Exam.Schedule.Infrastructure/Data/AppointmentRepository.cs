using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Schedules.Domain.Entities;
using Exam.Schedules.Domain.Repositories;

namespace Exam.Schedule.Infrastructure.Data
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly InMemoryContext _context;

        public AppointmentRepository(InMemoryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}