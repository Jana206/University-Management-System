using System.ComponentModel.DataAnnotations;

namespace StudentManagementWeb.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = "";

    }
}
