using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace SampleAppWeb.Models
{
    public class CreateStudentViewModel
    {
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
    }
}
