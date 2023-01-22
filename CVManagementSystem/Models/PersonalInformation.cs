namespace CVManagementSystem.Models
{
    public partial class PersonalInformation
    {
        public PersonalInformation()
        {
            CVs = new HashSet<CV>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Cityname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<CV> CVs { get; set; }
    }
}