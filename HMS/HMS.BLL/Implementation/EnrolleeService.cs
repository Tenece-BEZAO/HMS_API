using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Context;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HMS.BLL.Implementation
{
    public class EnrolleeService : IEnrolleeService
    {

        private readonly IRepository<Enrollee> _enrolleeRepository;
        private readonly IRepository<Plan> _planRepository;
        private readonly HmoDbContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EnrolleeService(IUnitOfWork unitOfWork, IMapper mapper, HmoDbContext context)
        {
            _unitOfWork = unitOfWork;
            _dbContext = context;
            _mapper = mapper;
            _enrolleeRepository = _unitOfWork.GetRepository<Enrollee>();
            _planRepository = _unitOfWork.GetRepository<Plan>();
        }

        public async Task DeleteEnrolleeAsync(int enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                throw new Exception("Enrollee not found");

            await _enrolleeRepository.DeleteAsync(enrollee);

            await _unitOfWork.SaveChangesAsync();
        }



        public async Task<EnrolleeDto> GetEnrolleeAsync(int enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                return null;

            var enrolleeDto = _mapper.Map<EnrolleeDto>(enrollee);

            return enrolleeDto;
        }

        public async Task<PlanDto> GetEnrolleePlan(int enrolleeId)
        {
            var enrolleePlan = await _dbContext.Enrollees
                .Where(e => e.Id == enrolleeId)
                .Select(e => e.Plan)
                .FirstOrDefaultAsync();

            if (enrolleePlan == null)
                throw new ArgumentException("This enrollee has not subscribed to a plan.");

            var planDto = _mapper.Map<PlanDto>(enrolleePlan);

            return planDto;

        }

        public async Task<IEnumerable<EnrolleeDto>> GetEnrolleesAsync()
        {
            var enrollees = await _enrolleeRepository.GetAllAsync(orderBy: e => e.OrderBy(en => en.Id));

            var enrolleesDto = _mapper.Map<IEnumerable<EnrolleeDto>>(enrollees);

            return enrolleesDto;
        }



        public async Task<EnrolleeDto> NewEnrolleeAsync(EnrolleeDto enrolleeDto)
        {
            var enrollee = _mapper.Map<Enrollee>(enrolleeDto);

            await _enrolleeRepository.AddAsync(enrollee);
            await _unitOfWork.SaveChangesAsync();

            return enrolleeDto;
        }

        public async Task SetEnrolleePlan(int enrolleeId, int planId)
        {
            var existingEnrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (existingEnrollee == null)
                throw new ArgumentException("Enrollee not found");

            var existingPlan = await _planRepository.GetByIdAsync(planId);

            if (existingPlan == null)
                throw new ArgumentException("Plan not found");

            existingEnrollee.PlanId = planId;

            await _unitOfWork.SaveChangesAsync();


        }




        public async Task<EnrolleeDto> UpdateEnrolleeAsync(int enrolleeId, EnrolleeDto enrolleeDTO)
        {
            var existingEnrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (existingEnrollee == null)
                throw new ArgumentException("Enrollee not found");

            var updatedEnrollee = _mapper.Map<EnrolleeDto>(existingEnrollee);

            await _unitOfWork.SaveChangesAsync();

            return updatedEnrollee;
        }
    }
}
