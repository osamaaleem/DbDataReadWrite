using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbDataReadWrite.DAL;
using System.ComponentModel.DataAnnotations;

namespace DbDataReadWrite.Models
{
    public class Department
    {
        [Display(Name = "Dep ID")]
        public int DempartmentID { get; set; }
        [Display(Name = "Department")]
        public string Name { get; set; }
        public List<SelectListItem> getDepartmentList()
        {
            DepartmentEntity departmentEntity = new DepartmentEntity();
            List<Department> departmentList = departmentEntity.GetList();
            List<SelectListItem> depList = new List<SelectListItem>();
            foreach (Department department in departmentList)
            {
                depList.Add(new SelectListItem { Value = department.DempartmentID.ToString(), Text = department.Name});
            }
            return depList;
        }
    }
}