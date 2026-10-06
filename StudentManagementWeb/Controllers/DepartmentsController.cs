using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementWeb.Data;
using StudentManagementWeb.Models;

namespace StudentManagementWeb.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Department> departments = await _context.Departments.ToListAsync();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
                return View(department);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            
            return View(department);

        }

        public async Task<IActionResult> Delete(int id)
        {
            Department? department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Department department)
        {
            bool hasStudents = await _context.Students.AnyAsync(student => student.DepartmentId == department.Id);

            if (hasStudents)
            {
                TempData["Error"] = "Cannot delete department because it has associated students";

                return RedirectToAction("Index");
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int id)
        {
            Department? department = await _context.Departments.FirstOrDefaultAsync(department => department.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            List<Student> students = await _context.Students.Where(student => student.DepartmentId == id).ToListAsync();

            ViewBag.Students = students;

            return View(department);
        }
    }
}
