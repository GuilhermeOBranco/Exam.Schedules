using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Schedules.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Schedule.Infrastructure.Data
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options): base(options){}

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

    }
}