using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbDataReadWrite.Models;
using DbDataReadWrite.DAL;

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
            ViewBag.departmentList = getDepartmentList();
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
            ViewBag.departmentList = getDepartmentList();
            return View();
        }
        private List<SelectListItem> getDepartmentList()
        {
            Department department = new Department();
            return department.getDepartmentList();
        }
    }
}