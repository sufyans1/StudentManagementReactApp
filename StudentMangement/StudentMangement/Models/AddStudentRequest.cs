namespace StudentMangement.Models
{
    public class AddStudentRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public string Course { get; set; }
    }
}
