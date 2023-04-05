
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;

namespace HMS.BLL.Interfaces
{
    public interface IProviderService
    {
        Task DeleteProviderAsync(int providerId);
        Task<ProviderDto> GetProviderAsync(int providerId);
        Task<IEnumerable<ProviderDto>> SearchProvidersAsync(string searchTerm);
        Task<IEnumerable<ProviderDto>> GetProvidersAsync();
        Task<ProviderDto> RegisterProviderAsync(ProviderDto providerDto);
        Task<ProviderDto> UpdateProviderAsync(int providerId, ProviderDto providerDto);
    }
}
