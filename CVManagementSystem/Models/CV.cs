namespace CVManagementSystem.Models
{
    public partial class CV
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Personal_Information_Id { get; set; }
        public int? Experience_Information_Id { get; set; }

        public virtual ExperienceInformation Experience_Information { get; set; }
        public virtual PersonalInformation Personal_Information { get; set; }
    }
}