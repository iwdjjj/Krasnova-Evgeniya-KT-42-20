using KrasnovaEV_KT_42_20.Database;
using KrasnovaEV_KT_42_20.Filters.SubjectFilters;
using KrasnovaEV_KT_42_20.Interfaces;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KrasnovaEV_KT_42_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ILogger<SubjectsController> _logger;
        private readonly ISubjectService _studentService;
        private StudentDbContext _context;

        public SubjectsController(ILogger<SubjectsController> logger, ISubjectService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _context = context;
        }

        [HttpPost("GetSubjectsByDescription")]
        public async Task<IActionResult> GetSubjectsByDescriptionAsync(SubjectDescriptionFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetSubjectsByDescriptionAsync(filter, cancellationToken);

            return Ok(students);
        }

        //[HttpPost("GetSubjectsByIsDeleted")]
        //public async Task<IActionResult> GetSubjectsByIsDeletedAsync(SubjectIsDeletedFilter filter, CancellationToken cancellationToken = default)
        //{
        //    var students = await _studentService.GetSubjectsByIsDeletedAsync(filter, cancellationToken);

        //    return Ok(students);
        //}

        [HttpPost("AddSubject")]
        public IActionResult CreateSubject([FromBody] Subject student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subjects.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditSubject")]
        public IActionResult UpdateSubject(string name, [FromBody] Subject updatedSubject)
        {
            var existingSubject = _context.Subjects.FirstOrDefault(g => g.SubjectName == name);

            if (existingSubject == null)
            {
                return NotFound();
            }

            existingSubject.SubjectName = updatedSubject.SubjectName;
            existingSubject.SubjectDescription = updatedSubject.SubjectDescription;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteSubject")]
        public IActionResult DeleteSubject(string name, [FromBody]  Subject deletedSubject)
        {
            var existingSubject = _context.Subjects.FirstOrDefault(g => g.SubjectName == name);

            if (existingSubject == null)
            {
                return NotFound();
            }
            //existingSubject.IsDeleted = true;
            _context.Subjects.Remove(existingSubject);
            _context.SaveChanges();

            return Ok();
        }
    }
}
