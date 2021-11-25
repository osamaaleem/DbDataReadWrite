using DbDataReadWrite.DAL;
using DbDataReadWrite.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DbDataReadWrite.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeEntity employee = new EmployeeEntity();
            List<Employee> employeeList = employee.GetEmployees();
            return View(employeeList);
        }
        public ActionResult AddEmp()
        {
            ViewBag.departmentList = getDepartmentList(0, 0);
            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int rowsAffected;
                EmployeeEntity employeeEntity = new EmployeeEntity();
                rowsAffected = employeeEntity.AddEmployee(employee);
                if (rowsAffected > 0)
                {
                    ViewBag.successMsg = "Values added";
                }

            }
            ViewBag.departmentList = getDepartmentList(0, 0);
            return View();
        }
        public ActionResult Details(int id)
        {
            Employee employee = new Employee();
            EmployeeEntity employeeEntity = new EmployeeEntity();
            employee = employeeEntity.GetEmployeeById(id);
            return View(employee);
        }
        public ActionResult Update(int id)
        {
            ViewBag.departmentList = getDepartmentList(1, id);
            Employee employee = new Employee();
            EmployeeEntity employeeEntity = new EmployeeEntity();
            employee = employeeEntity.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {

            if (ModelState.IsValid)
            {
                int rowsAffected;
                EmployeeEntity employeeEntity = new EmployeeEntity();
                rowsAffected = employeeEntity.UpdateEmployee(employee);
                if (rowsAffected > 0)
                {
                    ViewBag.successMsg = "Values Updated";
                }

            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();
            employeeEntity.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        private List<SelectListItem> getDepartmentList(int choice, int id)
        {
            Department department = new Department();
            switch (choice)
            {
                case 1:
                    return department.getDepartmentListById(id);
                default:
                    return department.getDepartmentList();
            }
        }
    }
}