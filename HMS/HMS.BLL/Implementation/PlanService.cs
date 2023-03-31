using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;

namespace HMS.BLL.Implementation
{
    public class PlanService : IPlanService
    {

        private readonly IRepository<Plan> _planRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlanService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _planRepository = _unitOfWork.GetRepository<Plan>();
        }


        public async Task DeletePlanAsync(int planId)
        {
            var plan = await _planRepository.GetByIdAsync(planId);

            if (plan == null)
                throw new Exception("Plan not found");

            await _planRepository.DeleteAsync(plan);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PlanDto> GetPlanByIdAsync(int planId)
        {
            var plan = await _planRepository.GetByIdAsync(planId);

            if (plan == null)
                return null;

            var planDto = _mapper.Map<PlanDto>(plan);

            return planDto;
        }

        public async Task<PlanDto> GetPlanByNameAsync(string name)
        {
            var plan = await _planRepository.GetByNameAsync(name);

            if (plan == null)
                return null;

            var planDto = _mapper.Map<PlanDto>(plan);

            return planDto;
        }

        public Task GetPlanDrugs(int planId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PlanDto>> GetPlansAsync()
        {
            var plans = await _planRepository.GetAllAsync(orderBy: e => e.OrderBy(en => en.Id));

            var planDto = _mapper.Map<IEnumerable<PlanDto>>(plans);

            return planDto;
        }

        public async Task<PlanDto> NewPlanAsync(PlanDto planDto)
        {
            var plan = _mapper.Map<Plan>(planDto);

            await _planRepository.AddAsync(plan);
            await _unitOfWork.SaveChangesAsync();

            return planDto;
        }

        public async Task<PlanDto> UpdatePlanAsync(int planId, PlanDto planDto)
        {
            var existingPlan = await _planRepository.GetByIdAsync(planId);

            if (existingPlan == null)
                throw new ArgumentException("Plan not found");

            var updatedPlan = _mapper.Map<PlanDto>(existingPlan);

            await _unitOfWork.SaveChangesAsync();

            return updatedPlan;
        }


    }
}
