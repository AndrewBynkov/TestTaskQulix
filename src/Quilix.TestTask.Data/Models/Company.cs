using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quilix.TestTask.Data.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }

        public string OrganizationForm { get; set; }
    }
}
