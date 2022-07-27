using SampleAppWeb.EntityFramework;

namespace SampleAppWeb.Uow
{
    public interface IStudentRepository : IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentID);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentID);
        void Save();

    }
}