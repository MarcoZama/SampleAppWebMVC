using SampleAppWeb.EntityFramework;

namespace SampleAppWeb.Models
{
    public class StudentsViewModel
    {
        public List<Student> Students { get; set; }
        public string Title { get; set; }

    }
}
