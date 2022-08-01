using EmployeeCrudApp.Data;
using EmployeeCrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string searchString)

        {
             ViewData["CreateNewEmployee"] = searchString;
            var movies = from s in _employeeDbContext.Employees select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.FirstName!.Contains(searchString) || s.City!.Contains(searchString) || s.MobileNumber!.Contains(searchString));
            }

            return View(await movies.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> Index()
        {
            var employee= await _employeeDbContext.Employees.ToListAsync();

            return View(employee);
        }
        public IActionResult CreateNewEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employees)
        {
            if(ModelState.IsValid)
            {
                _employeeDbContext.Employees.Add(employees);
                await _employeeDbContext.SaveChangesAsync();
               return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index));
            }

            return View(employees);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id<=0)
            {
                return BadRequest();
            }
            var employeesinDb=await _employeeDbContext.Employees.FirstOrDefaultAsync(x=> x.Id==id);
            if(employeesinDb==null)
            {
                return NotFound();
            }
            return View(employeesinDb);
        }
        public async Task<IActionResult> Save(Employee employees)
        {
            if (!ModelState.IsValid)
            {
                return View(employees);

            }           
            _employeeDbContext.Employees.Update(employees);
            await _employeeDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }


        public async Task<IActionResult> Delete(int? Id)
        {

            if (Id <= 0)
            {
                return BadRequest();
            }
            var employee = await _employeeDbContext.Employees.FirstOrDefaultAsync(m => m.Id == Id);
            if (Id == null)
            {
                return NotFound();
            }
            var employee1 = await _employeeDbContext.Employees.FindAsync(Id);
            _employeeDbContext.Employees.Remove(employee1);
            await _employeeDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

           // return View(employee);
        }

        // POST: Employees/Delete/1
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int Id)
        //{
            
        //}

    }
}
