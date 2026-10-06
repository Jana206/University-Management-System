using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWeb.Models;
using StudentManagementWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int totalStudents = await _context.Students.CountAsync();

            int totalDepartments = await _context.Departments.CountAsync();

            int activeStudents = await _context.Students.CountAsync(student => student.Status == StudentStatus.Active);

            int graduatedStudents = await _context.Students.CountAsync(student => student.Status == StudentStatus.Graduated);

            ViewBag.TotalStudents = totalStudents;
            ViewBag.TotalDepartments = totalDepartments;
            ViewBag.ActiveStudents = activeStudents;
            ViewBag.GraduatedStudents = graduatedStudents;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
