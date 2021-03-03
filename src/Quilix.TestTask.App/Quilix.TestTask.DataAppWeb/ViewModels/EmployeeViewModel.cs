using Quilix.TestTask.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quilix.TestTask.DataAppWeb.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Display(Name = "Second name")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Hiring date")]
        public DateTime HiringDate { get; set; }

        [Required]
        public PositionType Position { get; set; }

        public int CompanyId { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
    }
}
