using CVManagementSystem.Models;

namespace CVManagementSystem.Dto
{
    public class CVDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Personal_Information_Id { get; set; }
        public int? Experience_Information_Id { get; set; }
    }

    public class CVDtoPage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Personal_Information_Id { get; set; }
        public int? Experience_Information_Id { get; set; }
        public ExperienceInformationDto Experience_Information { get; set; }
        public PersonalInformationDto Personal_Information { get; set; }
    }
}
