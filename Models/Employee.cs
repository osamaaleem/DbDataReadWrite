using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbDataReadWrite.CustomValidation;
using DbDataReadWrite.DAL;

namespace DbDataReadWrite.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "ID")]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Required]
        //public string Gender { get; set; }
        //[Required]
        //[EmailAddress]
        //public string EmailAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Range(25000,50000,ErrorMessage = "Salary must be between 25000 and 50000")]
        public double Salary { get; set; }
        [Required]
        [Range(20,60,ErrorMessage = "Age must be between 20 and 60")]
        public int Age { get; set; }
        //[Required]
        //public int EducationLevel { get; set; }
        [Required]
        [DataType (DataType.Date)]
        [CustomHireDate(ErrorMessage = "Date must be less then or equal today's date")]
        public DateTime HireDate { get; set; }
        public string ShortHireDate { get; set; }
        public Department Department { get; set; }
        
    }
}