using StudentWebApi.Data.Repositories.Interface;
using StudentWebApi.Model;

namespace StudentWebApi.Data.Repositories.Implementation
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
