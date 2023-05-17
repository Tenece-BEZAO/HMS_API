using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Context;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
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

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public EnrolleeService(IUnitOfWork unitOfWork, IMapper mapper, HmoDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)

        {
            _unitOfWork = unitOfWork;
            _dbContext = context;
            _mapper = mapper;
            _enrolleeRepository = _unitOfWork.GetRepository<Enrollee>();

            _roleManager = roleManager;
            _userManager = userManager;
            _planRepository = _unitOfWork.GetRepository<Plan>();

        }

        public async Task DeleteEnrolleeAsync(string enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                throw new Exception("Enrollee not found");

            await _enrolleeRepository.DeleteAsync(enrollee);

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<EnrolleeDto> GetEnrolleeAsync(string enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                return null;

            var enrolleeDto = _mapper.Map<EnrolleeDto>(enrollee);

            return enrolleeDto;
        }

        public async Task<PlanDto> GetEnrolleePlanAsync(string enrolleeId)
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




        public async Task<string> CreateEnrolleeAsync(EnrolleeDto enrolleeDto)

        {
            if (enrolleeDto == null)
                throw new ArgumentNullException(nameof(enrolleeDto));


            var enrollee = _mapper.Map<Enrollee>(enrolleeDto);

            await _enrolleeRepository.AddAsync(enrollee);

            await _unitOfWork.SaveChangesAsync();

            return enrollee.Id;
        }



        public async Task<EnrolleeDto> NewEnrolleeAsync(EnrolleeDto enrolleeDTO)
        {
            var enrollee = _mapper.Map<Enrollee>(enrolleeDTO);
            await _roleManager.CreateAsync(new IdentityRole("Enrollee"));
          //  await _userManager.AddToRoleAsync(enrollee, "Enrollee");
          //  enrollee.RegisteredDate = DateTime.Now;
            await _enrolleeRepository.AddAsync(enrollee);
            await _unitOfWork.SaveChangesAsync();

            return enrolleeDTO;
        }

        public async Task SubscribeToPlanAsync(string enrolleeId, int planId)
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


        public async Task UpdateEnrolleeAsync(string enrolleeId, EnrolleeDto enrolleeDto)
        {

            if (enrolleeDto == null)
                throw new ArgumentNullException(nameof(enrolleeDto));

            var existingEnrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);


            if (existingEnrollee == null)
                throw new ArgumentException("Enrollee does not exist");

            _mapper.Map(enrolleeDto, existingEnrollee);
            await _enrolleeRepository.UpdateAsync(existingEnrollee);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UnsubscribeFromPlanAsync(string enrolleeId)
        {
            var enrollee = await _enrolleeRepository.GetByIdAsync(enrolleeId);

            if (enrollee == null)
                throw new ArgumentException("Enrollee not found");

            enrollee.PlanId = null;

            await _unitOfWork.SaveChangesAsync();
        }

    
    }
}
