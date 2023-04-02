using HMS.DAL.Dtos.Requests;

namespace HMS.BLL.Interfaces
{
    public interface IDrugService
    {
        Task<IEnumerable<DrugDto>> GetDrugsAsync();
        Task<DrugDto> GetDrugByIdAsync(int drugId);
        Task<DrugDto> GetDrugByNameAsync(string drugName);
        Task<DrugDto> NewDrugAsync(DrugDto drugDto);
        Task<DrugDto> UpdateDrugAsync(int drugId, DrugDto drugDto);
        Task DeletDrugAsync(int drugId);
    }
}
