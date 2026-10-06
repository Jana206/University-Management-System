using System.ComponentModel.DataAnnotations;

namespace StudentManagementWeb.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required][StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = "";
        [Range (15, 100)]
        public int Age { get; set; }
        [Range (0, 100)]
        public double Grade { get; set; }
        public StudentStatus Status { get; set; } 

        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }

    public enum StudentStatus
    {
        Active,
        Graduated,
        Suspended
    }
}
