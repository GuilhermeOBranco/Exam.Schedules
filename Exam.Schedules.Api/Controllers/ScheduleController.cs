using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Schedules.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Schedules.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateSchedule")]
        public async Task<IActionResult> CreateSchedule([FromBody] CreateAppointmentRequest request)
        {
            try
            {
                var command = new ScheduleAppointmentCommand(request.PatientName, request.DoctorName, request.ScheduledStartDate, request.ScheduledEndDate);

                var result = await _mediator.Send(command);

                return Ok(result);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }


        }
    }

    public class CreateAppointmentRequest
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
    }
}