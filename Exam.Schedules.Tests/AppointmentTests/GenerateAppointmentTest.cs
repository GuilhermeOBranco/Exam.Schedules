using System;
using System.Collections.Generic;
using System.Linq;
using Exam.Schedules.Domain.Entities;
using Xunit;

namespace Exam.Schedules.Tests.AppointmentTests
{
    public class GenerateAppointmentTest
    {

        [Fact]
        public void CreatingAppointment_WithInvalidDates_ShouldThrowException()
        {
            Patient patient = new Patient("Joao");
            Doctor doctor = new Doctor("Frederico");

            var invalidStartDate = DateTime.Now;
            var invalidEndDate = invalidStartDate.AddMinutes(30);

            TimeSpan duration = (invalidEndDate - invalidStartDate);

            var exception = Record.Exception(() =>
                new Appointment(patient, doctor, invalidStartDate, invalidEndDate)
            );

            Assert.NotNull(exception);

            Assert.IsType<ArgumentException>(exception);
            
            Assert.Equal("Nao eh uma data valida para criacao de um agendamento", exception.Message);
        }

        [Fact]
        public void CreatingAppointment_WithValidDates_ShouldNotThrowException()
        {
            // Arrange
            var patient = new Patient("Joao");
            var doctor = new Doctor("Frederico");
            var validStartDate = DateTime.Now;
            var validEndDate = validStartDate.AddHours(1); // Exatamente uma hora de diferença

            // Act & Assert
            var exception = Record.Exception(() =>
                new Appointment(patient, doctor, validStartDate, validEndDate)
            );

            Assert.Null(exception);
        }
    }
}