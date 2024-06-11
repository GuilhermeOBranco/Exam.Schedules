using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Schedules.Domain.Entities;

namespace Exam.Schedules.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetByIdAsync(Guid id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(Guid id);
    }
}