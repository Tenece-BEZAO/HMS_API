using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IReportService _reportService;

        public AppointmentController(IAppointmentService appointmentService, IReportService reportService)
        {
            _appointmentService = appointmentService;
            _reportService = reportService; 
        }

        [Authorize]
        [HttpGet]
        [Route("GetAppointments")]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointmentsAsync();
            return Ok(appointments);
        }


        [HttpGet("GetAppointment/{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointmentDto = await _appointmentService.GetAppointmentAsync(id);

            if (appointmentDto == null)
            {
                return NotFound();
            }

            return appointmentDto;
        }


        [HttpGet("SearchAppointment")]
        public async Task<IActionResult> SearchAppointments(string searchTerm)
        {
            var appointment = await _appointmentService.SearchAppointmentsAsync(searchTerm);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        [HttpPost]
        [Route("NewAppointment")]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest("Appointment cannot be created. Please try again!");
            }

            var addedAppointmentDto = await _appointmentService.AddAppointmentAsync(appointmentDto);

            var reportDto = new ReportDto
            {
                Name = addedAppointmentDto.EnrolleeName,
                Reason = addedAppointmentDto.Reason,
                ReportDate = addedAppointmentDto.AppointmentDate
            };

            await _reportService.AddReportAsync(reportDto);

            return CreatedAtAction(nameof(GetAppointment), new { id = addedAppointmentDto.Id }, addedAppointmentDto);
        }


        [HttpPut("UpdateAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDto appointmentDto)
        {
            try
            {
                var updatedAppointmentDto = await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);

                if (updatedAppointmentDto == null)
                {
                    return BadRequest("Failed to update appointment details. Please try again.");
                }
                return Ok(updatedAppointmentDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Updating appointment details failed,try again! ");
            }
        }


        [HttpPut("RejectAppointment/{id}")]
        public async Task<IActionResult> RejectAppointment(int id)
        {
            try
            {
                var appointmentDto = await _appointmentService.GetAppointmentAsync(id);

                if (appointmentDto == null)
                {
                    return NotFound("Appointment not found");
                }

                appointmentDto.Status = Status.Rejected;
                await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);

                return Ok("Appointment rejected successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut("ConfirmAppointment/{id}")]
        public async Task<IActionResult> ConfirmAppointment(int id)
        {
            try
            {
                var appointmentDto = await _appointmentService.GetAppointmentAsync(id);

                if (appointmentDto == null)
                {
                    return NotFound("Appointment not found");
                }

                appointmentDto.Status = Status.Confirmed;
                await _appointmentService.UpdateAppointmentAsync(id, appointmentDto);

                return Ok("Appointment confirmed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete("DeleteAppointment/{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                await _appointmentService.DeleteAppointmentAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

