using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssessmentApp.Data;
using AssessmentApp.Models;
using AssessmentApp.Repository;

namespace AssessmentApp.Controllers
{
    public class DepartmentsController : Controller
    {
        IDepartment _context;



        public DepartmentsController(IDepartment repo)
        {
            _context = repo;
        }




        // GET: Departments

        public IActionResult Index()
        {
            var dept = _context.GetAllDept();
            return View(dept);
       
        
        }

     
        public IActionResult Details(int id)
        {
            var dept = _context.GetDeptById(id);
            return View(dept);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var dept = _context.AddDept(department);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        // GET: Departments/Edit/5
        public IActionResult Edit(int id)
        {
            var dept = _context.GetDeptById(id);
            return View(dept);
        }

        [HttpPost]
      
        public IActionResult Edit(int id, Department department)
        {
          var dept = _context.UpdateDept(department.Id, department);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var dept = _context.DeleteDept(id);
            return RedirectToAction(controllerName: "Departments", actionName: "Index");
        }


      
    }
}
