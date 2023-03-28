using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Enums;
using HMS.DAL.Interfaces;


namespace HMS.BLL.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appointmentRepository = _unitOfWork.GetRepository<Appointment>();
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync(orderBy: q => q.OrderBy(a => a.AppointmentDate));
            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return appointmentDtos;
        }


        public async Task<AppointmentDto> GetAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return null;
            }

            var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

            return appointmentDto;
        }


        public async Task<IEnumerable<AppointmentDto>> SearchAppointmentsAsync(string searchTerm)
        {
            var appointments = await _appointmentRepository.GetByAsync(a => a.EnrolleeName.ToLower().Contains(searchTerm.ToLower()) ||
                                   a.Reason.ToLower().Contains(searchTerm.ToLower()),
                                   orderBy: q => q.OrderBy(a => a.AppointmentDate));

            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return appointmentDtos;
        }


        public async Task RejectAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null)
            {
                throw new ArgumentException("Appointment not found.");
            }

            appointment.Status = Status.Rejected;
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task ConfirmAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (appointment == null)
            {
                throw new ArgumentException("Appointment not found.");
            }

            appointment.Status = Status.Confirmed;
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

            if (appointment == null)
            {
                throw new ArgumentException("Appointment not found.");
            }

            await _appointmentRepository.DeleteAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<AppointmentDto> AddAppointmentAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            await _appointmentRepository.AddAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return appointmentDto;
        }


        public async Task<AppointmentDto> UpdateAppointmentAsync(int appointmentId, AppointmentDto appointmentDto)
        {
            var existingAppointment = await _appointmentRepository.GetByIdAsync(appointmentId);
            if (existingAppointment == null)
            {
                throw new ArgumentException("Appointment not found.");
            }

            existingAppointment.EnrolleeName = appointmentDto.EnrolleeName;
            existingAppointment.Reason = appointmentDto.Reason;
            existingAppointment.AppointmentDate = appointmentDto.AppointmentDate;

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AppointmentDto>(existingAppointment);
        }
    }
}
