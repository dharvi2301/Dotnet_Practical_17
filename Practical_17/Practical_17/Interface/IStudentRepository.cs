using Practical_17.Models;

namespace Practical_17.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task AddStudent(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
