using Quilix.TestTask.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quilix.TestTask.DataAppWeb.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Organization form")]
        public string OrganizationForm { get; set; }
    }
}
