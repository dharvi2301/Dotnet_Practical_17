using Microsoft.AspNetCore.Mvc;
using Practical_17.Data;
using Practical_17.Models;
using Practical_17.Repository;

namespace Practical_17.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StudentRepository _studentRepository;

        public StudentController(ApplicationDbContext context)
        {
            _studentRepository = new StudentRepository(context);
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Task<IEnumerable<Student>> students = _studentRepository.GetStudentsAsync();
            return View(await students);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,Email,PhoneNumber,Address,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Email,PhoneNumber,Address,EnrollmentDate")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _studentRepository.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // Fix for CS1503: Argument 1: cannot convert from 'method group' to 'int'
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Fix for CS1503: Argument 1: cannot convert from 'method group' to 'int'
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _studentRepository.GetStudentAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
