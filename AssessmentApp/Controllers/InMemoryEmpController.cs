using AssessmentApp.Models;
using AssessmentApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentApp.Controllers
{
    public class InMemoryEmpController : Controller
    {


        IIEmployee _repo1;

        public InMemoryEmpController(IIEmployee repo1)
        {
            _repo1 = repo1;
        }



   
        public IActionResult InMemoryDetails(int id)
        {

            var inMemory = _repo1.GetInDeptById(id);
            return View(inMemory);

        }

        public IActionResult GetALlEmp()
        {

            var inMemory = _repo1.GetInAllEmp();
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
                var emp = _repo1.AddInMemoryEmp(newEmp);
                return RedirectToAction("GetALlEmp");
            }
            ViewData["Message"] = "Data is not valid to create the Todo";
            return View();
        }


        [HttpGet]
        public IActionResult InMemoryUpdate(int empId)
        {
            var oldEmp = _repo1.GetInEmpById(empId);
            return View(oldEmp);
        }
        [HttpPost]
        public IActionResult InMemoryUpdate(Employee newEmp)
        {
            var Emp = _repo1.UpdateInMemoryEmp(newEmp.Id, newEmp);
            return RedirectToAction("GetALlEmp");
        }

        public IActionResult InMemoryDelete(int id)
        {
            var emp = _repo1.DeleteInMemoryEmp(id);
            return RedirectToAction(controllerName: "InMemoryEmp", actionName: "GetALlEmp");

        }
    }
}
