using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;

namespace HMS.BLL.Implementation
{
    public class DrugService : IDrugService
    {
        private readonly IRepository<Drug> _drugRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DrugService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _drugRepository = _unitOfWork.GetRepository<Drug>();
        }

        public async Task DeletePlanAsync(int drugId)
        {
            var drug = await _drugRepository.GetByIdAsync(drugId);

            if (drug == null)
                throw new Exception("Plan not found");

            await _drugRepository.DeleteAsync(drug);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<DrugDto> GetDrugByIdAsync(int drugId)
        {
            var drug = await _drugRepository.GetByIdAsync(drugId);

            if (drug == null)
                return null;

            var drugDto = _mapper.Map<DrugDto>(drug);

            return drugDto;
        }

        public async Task<DrugDto> GetDrugByNameAsync(string drugName)
        {
            var drug = await _drugRepository.GetByNameAsync(drugName);

            if (drug == null)
                return null;

            var drugDto = _mapper.Map<DrugDto>(drug);

            return drugDto;
        }

        public async Task<IEnumerable<DrugDto>> GetDrugsAsync()
        {
            var drugs = await _drugRepository.GetAllAsync(orderBy: d => d.OrderBy(d => d.Id));

            var drugDto = _mapper.Map<IEnumerable<DrugDto>>(drugs);

            return drugDto;
        }

        public async Task<DrugDto> NewDrugAsync(DrugDto drugDto)
        {
            var drug = _mapper.Map<Drug>(drugDto);

            await _drugRepository.AddAsync(drug);
            await _unitOfWork.SaveChangesAsync();

            return drugDto;
        }

        public async Task<DrugDto> UpdateDrugAsync(int drugId, DrugDto drugDto)
        {
            var existingDrug = await _drugRepository.GetByIdAsync(drugId);

            if (existingDrug == null)
                throw new ArgumentException("Drug not found");

            var updatedDrug = _mapper.Map<DrugDto>(existingDrug);

            await _unitOfWork.SaveChangesAsync();

            return updatedDrug;
        }
    }
}
