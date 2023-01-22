using CVManagementSystem.Dto;

namespace CVManagementSystem.Interface
{
    public interface ICV
    {
        Task<CVDtoPage> GetById(int id);
        Task<List<CVDto>> GetAll();
        Task<int> Insert(CVDto model);
        Task<int> Update(CVDto model);
        Task<int> Delete(int id);
    }
}
