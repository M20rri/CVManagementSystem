using CVManagementSystem.Dto;

namespace CVManagementSystem.Interface
{
    public interface IExperienceInformation
    {
        Task<ExperienceInformationDto> GetById(int id);
        Task<int> Insert(ExperienceInformationDto model);
        Task<int> Update(ExperienceInformationDto model);
    }
}
