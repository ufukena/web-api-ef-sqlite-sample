using Microsoft.EntityFrameworkCore;
using SchoolAPI.DataAccess;
using SchoolAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SchoolAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context) { 
        
            _context = context;
        }

        public async Task<Student> Create(Student student)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            
            return student;
        }

        public async Task Delete(int id)
        {
            var studentToDelete = await _context.Students.FindAsync(id);
            
            if (studentToDelete != null){
                _context.Students.Remove(studentToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}
