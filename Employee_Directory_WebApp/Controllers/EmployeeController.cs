


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Directory_WebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Employee_Directory_WebApp.Data;
using Microsoft.Extensions.Logging;

namespace Employee_Directory_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EmployeeController> _logger;  // Add logger

        public EmployeeController(ApplicationDbContext context, ILogger<EmployeeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchString, string location, string department, string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DepartmentSortParm"] = sortOrder == "Department" ? "department_desc" : "Department";
            ViewData["PositionSortParm"] = sortOrder == "Position" ? "position_desc" : "Position";

            var employees = from e in _context.Employees
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString)
                                       || s.Department.Contains(searchString)
                                       || s.Position.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(location))
            {
                employees = employees.Where(e => e.Position == location);
            }

            if (!String.IsNullOrEmpty(department))
            {
                employees = employees.Where(e => e.Department == department);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;
                case "Department":
                    employees = employees.OrderBy(s => s.Department);
                    break;
                case "department_desc":
                    employees = employees.OrderByDescending(s => s.Department);
                    break;
                case "Position":
                    employees = employees.OrderBy(s => s.Position);
                    break;
                case "position_desc":
                    employees = employees.OrderByDescending(s => s.Position);
                    break;
                default:
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }
            // Log the query for debugging
            _logger.LogInformation("Employees query: {Query}", employees.ToQueryString());

            return View(await employees.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Leaves)
                .Include(e => e.Attendances)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            ModelState.Remove(nameof(employee.Leaves));
            ModelState.Remove(nameof(employee.Attendances));

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Employee added successfully" });
            }

            return Json(new { success = false, message = "Failed to add employee" });
        }
    }
}





//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Employee_Directory_WebApp.Models;
//using System.Linq;
//using System.Threading.Tasks;
//using Employee_Directory_WebApp.Data;

//namespace Employee_Directory_WebApp.Controllers
//{
//    public class EmployeeController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public EmployeeController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var employees = await _context.Employees.ToListAsync();
//            return View(employees);
//        }


//        public async Task<IActionResult> Details(int id)
//        {
//            var employee = await _context.Employees
//                .Include(e => e.Leaves)
//                .Include(e => e.Attendances)
//                .FirstOrDefaultAsync(e => e.Id == id);

//            if (employee == null)
//            {
//                return NotFound();
//            }

//            return View(employee);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
//        {
//            ModelState.Remove(nameof(employee.Leaves));
//            ModelState.Remove(nameof(employee.Attendances));
//            if (ModelState.IsValid)
//            {
//                _context.Employees.Add(employee);
//                await _context.SaveChangesAsync();
//                return Json(new { success = true, message = "Employee added successfully" });
//        }
//            return Json(new { success = false, message = "Failed to add employee" });
//        }


//    }
//}