using KrasnovaEV_KT_42_20.Database;
using KrasnovaEV_KT_42_20.Interfaces;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KrasnovaEV_KT_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcademicsController : ControllerBase
    {
        private readonly ILogger<AcademicsController> _logger;
        private StudentDbContext _context;

        public AcademicsController(ILogger<AcademicsController> logger, StudentDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("AddGrade")]
        public IActionResult CreateGrade([FromBody] Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grades.Add(grade);
            _context.SaveChanges();
            return Ok(grade);
        }

        [HttpPut("EditGrade")]
        public IActionResult UpdateGrade(int stu, [FromBody] Grade updatedGrade)
        {
            var existingGrade = _context.Grades.FirstOrDefault(h => h.StudentId == stu);

            if (existingGrade == null)
            {
                return NotFound();
            }

            existingGrade.GradeNumber = updatedGrade.GradeNumber;
            existingGrade.GradeDate = updatedGrade.GradeDate;
            existingGrade.SubjectId = updatedGrade.SubjectId;
            existingGrade.StudentId = updatedGrade.StudentId;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteGrade")]
        public IActionResult DeleteGrade(int stu, [FromBody] Grade deletedStudent)
        {
            var existingGrade = _context.Grades.FirstOrDefault(g => g.StudentId == stu);

            if (existingGrade == null)
            {
                return NotFound();
            }
            _context.Grades.Remove(existingGrade);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("AddExam")]
        public IActionResult CreateExam([FromBody] Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Exams.Add(exam);
            _context.SaveChanges();
            return Ok(exam);
        }

        [HttpPut("EditExam")]
        public IActionResult UpdateExam(int stu, [FromBody] Exam updatedExam)
        {
            var existingExam = _context.Exams.FirstOrDefault(h => h.StudentId == stu);

            if (existingExam == null)
            {
                return NotFound();
            }

            existingExam.ExamName = updatedExam.ExamName;
            existingExam.DateOfTest = updatedExam.DateOfTest;
            existingExam.ExamCondition = updatedExam.ExamCondition;
            existingExam.SubjectId = updatedExam.SubjectId;
            existingExam.StudentId = updatedExam.StudentId;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteExam")]
        public IActionResult DeleteExam(int stu, [FromBody] Exam deletedExam)
        {
            var existingExam = _context.Exams.FirstOrDefault(g => g.StudentId == stu);

            if (existingExam == null)
            {
                return NotFound();
            }
            _context.Exams.Remove(existingExam);
            _context.SaveChanges();

            return Ok();
        }
    }
}
