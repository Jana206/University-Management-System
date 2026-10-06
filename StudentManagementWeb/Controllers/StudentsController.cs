using Microsoft.AspNetCore.Mvc;
using StudentManagementWeb.Models;
using StudentManagementWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(int? departmentId, StudentStatus? status)
        {
            var studentsQuery = _context.Students.Include(student => student.Department).AsQueryable();

            if (departmentId.HasValue)
            {
                studentsQuery = studentsQuery.Where(student => student.DepartmentId == departmentId.Value);
            }

            if (status.HasValue)
            {
                studentsQuery = studentsQuery.Where(student => student.Status == status.Value);
            }

            List<Student> students = await studentsQuery.ToListAsync();

            ViewBag.Departments = await _context.Departments.ToListAsync();
            ViewBag.SelectedDepartmentId = departmentId;
            ViewBag.SelectedStatus = status;

            return View(students);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _context.Departments.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {

            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = await _context.Departments.ToListAsync();
            return View(student);

        }

        public async Task<IActionResult> Edit(int id)
        {
            Student? student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Departments = await _context.Departments.ToListAsync();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid) 
            { 
                _context.Students.Update(student);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); 
            }

            ViewBag.Departments = await _context.Departments.ToListAsync();
            return View(student);

        }

        public async Task<IActionResult> Delete(int id)
        {
            Student? student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Search(int id)
        {
            Student? student = await _context.Students.Include(student => student.Department).FirstOrDefaultAsync(student => student.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        public async Task<IActionResult> Passed()
        {
           List<Student> students = await _context.Students.Include(student => student.Department).Where(student => student.Grade >= 50).ToListAsync();

            return View(students);
        }

    }
}


