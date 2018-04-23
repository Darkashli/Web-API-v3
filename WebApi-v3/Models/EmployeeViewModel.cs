using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_v3.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? Gender { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? Functions { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? Salary { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime? HireDate { get; set; }
    }
}