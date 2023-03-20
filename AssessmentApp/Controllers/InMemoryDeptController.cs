using AssessmentApp.Models;
using AssessmentApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApp.Controllers
{
    public class InMemoryDeptController : Controller
    {


        IIDepartment _repo1;

        public InMemoryDeptController(IIDepartment repo1)
        {
            _repo1 = repo1;
        }

        public IActionResult InMemoryDetails(int id)
        {

            var inMemory = _repo1.GetInDeptById(id);
            return View(inMemory);

        }

        public IActionResult GetALlDept()
        {

            var inMemory = _repo1.GetInAllDept();
            return View(inMemory);
        }

        [HttpGet]
        public IActionResult InMemoryCreate()
        {
            return View();
        }

        public IActionResult InMemoryCreate(Employee newEmp) // model binded this where the views data is accepted 
        {
            if (ModelState.IsValid)
            {
                var emp = _repo1.AddInMemoryDept;
                return RedirectToAction("GetALlDept");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }


        [HttpGet]
        public IActionResult InMemoryUpdate(int empId)
        {
            var oldEmp = _repo1.GetInDeptById(empId);
            return View(oldEmp);
        }
        [HttpPost]
        public IActionResult InMemoryUpdate(Department newEmp)
        {
            var Emp = _repo1.UpdateInMemoryDept(newEmp.Id, newEmp);
            return RedirectToAction("GetALlDept");
        }

        public IActionResult InMemoryDelete(int id)
        {
            var emp = _repo1.DeleteInMemoryDept(id);
            return RedirectToAction(controllerName: "InMemoryDept", actionName: "GetALlDept");

        }
    }
}
