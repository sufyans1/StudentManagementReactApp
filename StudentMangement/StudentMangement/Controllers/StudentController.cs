using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMangement.Data;
using StudentMangement.Models;

namespace StudentMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentManagementDbContext dbContext;

        public StudentController(StudentManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok(await dbContext.Students.ToListAsync());
        }



        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentRequest addStudent)
        {
            var student = new StudentModel()
            {
                StudentId = Guid.NewGuid(),
                Name = addStudent.Name,
                Age = addStudent.Age,
                Dob = addStudent.Dob,
                Course = addStudent.Course

            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, UpdateStudentRequest update)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                student.Name = update.Name;
                student.Age = update.Age;
                student.Dob = update.Dob;
                student.Course = update.Course;
                dbContext.SaveChanges();
                return Ok(student);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                dbContext.Remove(student);
                dbContext.SaveChanges();
                return Ok(student);
            }
            return NotFound();
        }
    }
}
