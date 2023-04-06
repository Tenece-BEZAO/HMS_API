using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;

namespace HMS.BLL.Implementation
{
    public class EnrolleeService : IEnrolleeService
    {

        private readonly IRepository<Enrollee> _enrolleeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnrolleeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _enrolleeRepository = _unitOfWork.GetRepository<Enrollee>();
        }

        public async Task DeleteEnrolleeAsync(int enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                throw new Exception("Enrollee not found");

            await _enrolleeRepository.DeleteAsync(enrollee);

            await _unitOfWork.SaveChangesAsync();
        }



        public async Task<EnrolleeDTO> GetEnrolleeAsync(int enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                return null;

            var enrolleeDto = _mapper.Map<EnrolleeDTO>(enrollee);

            return enrolleeDto;
        }



        public async Task<IEnumerable<EnrolleeDTO>> GetEnrolleesAsync()
        {
            var enrollees = await _enrolleeRepository.GetAllAsync(orderBy: e => e.OrderBy(en => en.Id));

            var enrolleesDto = _mapper.Map<IEnumerable<EnrolleeDTO>>(enrollees);

            return enrolleesDto;
        }


        public async Task<EnrolleeDTO> NewEnrolleeAsync(EnrolleeDTO enrolleeDTO)
        {
            var enrollee = _mapper.Map<Enrollee>(enrolleeDTO);

            await _enrolleeRepository.AddAsync(enrollee);
            await _unitOfWork.SaveChangesAsync();

            return enrolleeDTO;
        }


        public async Task<EnrolleeDTO> UpdateEnrolleeAsync(int enrolleeId, EnrolleeDTO enrolleeDTO)
        {
            var existingEnrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (existingEnrollee == null)
                throw new ArgumentException("Enrollee not found");

            var updatedEnrollee = _mapper.Map<EnrolleeDTO>(existingEnrollee);

            await _unitOfWork.SaveChangesAsync();

            return updatedEnrollee;
        }
    }
}
