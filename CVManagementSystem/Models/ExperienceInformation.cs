namespace CVManagementSystem.Models
{
    public partial class ExperienceInformation
    {
        public ExperienceInformation()
        {
            CVs = new HashSet<CV>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompanyField { get; set; }

        public virtual ICollection<CV> CVs { get; set; }
    }
}