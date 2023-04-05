using AutoMapper;
using HMS.BLL.Interfaces;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Interfaces;

namespace HMS.BLL.Implementation
{
    public class ProviderService : IProviderService
    {
        private readonly IRepository<Provider> _providerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _providerRepository = _unitOfWork.GetRepository<Provider>();
        }


        public async Task<IEnumerable<ProviderDto>> SearchProvidersAsync(string searchTerm)
        {
            var providers = await _providerRepository.GetByAsync(p => p.Name.ToLower().Contains(searchTerm.ToLower()) ||
                                   p.Specialty.ToLower().Contains(searchTerm.ToLower()),
                                   orderBy: q => q.OrderBy(p => p.RegisteredDate));

            var providerDto = _mapper.Map<IEnumerable<ProviderDto>>(providers);
            return providerDto;
        }


        public async Task DeleteProviderAsync(int providerId)
        {
            var provider = await _providerRepository.GetByIdAsync(providerId);

            if (provider == null)
                throw new Exception("Enrollee not found");

            await _providerRepository.DeleteAsync(provider);

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<ProviderDto> GetProviderAsync(int providerId)
        {
            var provider = await _providerRepository.GetByIdAsync(providerId);

            if (provider == null)
                return null;

            var providerDto = _mapper.Map<ProviderDto>(provider);

            return providerDto;
        }


        public async Task<IEnumerable<ProviderDto>> GetProvidersAsync()
        {
            var providers = await _providerRepository.GetAllAsync(orderBy: p => p.OrderBy(p => p.Name));

            var providerDto = _mapper.Map<IEnumerable<ProviderDto>>(providers);

            return providerDto;
        }


        public async Task<ProviderDto> RegisterProviderAsync(ProviderDto providerDto)
        {
            var provider = _mapper.Map<Provider>(providerDto);
            provider.RegisteredDate = DateTime.Now;

            await _providerRepository.AddAsync(provider);
            await _unitOfWork.SaveChangesAsync();

            return providerDto;
        }


        public async Task<ProviderDto> UpdateProviderAsync(int providerId, ProviderDto providerDto)
        {
            var existingProvider = await _providerRepository.GetByIdAsync(providerId);

            if (existingProvider == null)
                throw new ArgumentException("Provider not found");

            var updatedProvider = _mapper.Map<ProviderDto>(existingProvider);

            await _unitOfWork.SaveChangesAsync();

            return updatedProvider;
        }
    }
}
