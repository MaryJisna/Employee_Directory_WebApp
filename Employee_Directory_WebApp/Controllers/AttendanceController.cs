using Employee_Directory_WebApp.Data;
using Employee_Directory_WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory_WebApp.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Attendances.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Employee", new { id = attendance.EmployeeId });
            }
            return View(attendance);
        }
    }
}
