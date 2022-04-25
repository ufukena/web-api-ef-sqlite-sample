using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;


        public StudentsController (IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents() {

            return await _studentRepository.Get();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudents(int id){

            return await _studentRepository.Get(id);
        }


        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent([FromBody] Student student) {

            var newStudent = await _studentRepository.Create(student);

            return CreatedAtAction(nameof(GetStudents), new { id = newStudent.Id }, newStudent);
        }


        [HttpPut]
        public async Task<ActionResult> PutStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id) {
                return BadRequest();
            }

            await _studentRepository.Update(student);

            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var studentDelete = await _studentRepository.Get(id);

            if (studentDelete == null){
                return NotFound();
            }

            await _studentRepository.Delete(studentDelete.Id);
            return NoContent();
        }



    }
}
