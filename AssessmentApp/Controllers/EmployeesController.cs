using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentApp.Data;
using AssessmentApp.Models;
using AssessmentApp.Repository.MsSQL;
using AssessmentApp.Repository.InMemory;
using AssessmentApp.Repository;

namespace AssessmentApp.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployee _context;
        private readonly EMSDbContext _repo;

       

        public EmployeesController(IEmployee repo, EMSDbContext rep)
        {
            this._context = repo;
            _repo = rep;
          
        }
    

        // GET: Employees
        public IActionResult Index()
        {
            var emp = _context.GetAllEmp();
            //var inMemory = _repo1.GetAllEmp();
            return View(emp);
        }


        //Get: InMemory

        



        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            var emp = _context.GetEmpById(id);
            emp.DepartmentName = _context.GetDeptById(id).DeptName;
            return View(emp);   

          
        }
        
        //Details: InMemory
       


        // GET: Employees/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {

                var emp = _context.AddEmp(employee);
                return RedirectToAction("Index");

            }
            ViewData["Message"] = "Data is not valid to create the Employee";
            return View();
        }


        


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repo.Employees == null)
            {
                return NotFound();
            }

            var employee = await _repo.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_repo.Departments, "Id", "DeptName", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpName,EmpDob,EmpPhone,DepartmentId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(employee);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_repo.Departments, "Id", "DeptName", employee.DepartmentId);
            return View(employee);
        }


       


        private bool EmployeeExists(int id)
        {
            return (_repo.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IActionResult Delete(int id)
        {
            var emp = _context.DeleteEmp(id);
            return RedirectToAction(controllerName: "Employees", actionName: "Index");
            
        }

       

    }
}
