using SchoolAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolAPI.Repositories
{
    public interface IStudentRepository
    {

        Task<IEnumerable<Student>> Get();

        Task<Student> Get(int id);

        Task<Student> Create(Student student);

        Task Update(Student student);

        Task Delete(int id);


    }

}
