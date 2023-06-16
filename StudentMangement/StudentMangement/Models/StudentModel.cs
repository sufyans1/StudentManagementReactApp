using System.ComponentModel.DataAnnotations;

namespace StudentMangement.Models
{
    public class StudentModel
    {
        [Key]
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }
        public string Course { get; set; }

    }
}
