using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRU_DMV_CAPP.Models
{
    public class empmodelcs
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Company is required")]
        public string Company { get; set; }
        public int Salary { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
    }
}