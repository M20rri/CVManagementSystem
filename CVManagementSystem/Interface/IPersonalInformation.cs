using CVManagementSystem.Dto;

namespace CVManagementSystem.Interface
{
    public interface IPersonalInformation
    {
        Task<PersonalInformationDto> GetById(int id);
        Task<int> Insert(PersonalInformationDto model);
        Task<int> Update(PersonalInformationDto model);
    }
}
