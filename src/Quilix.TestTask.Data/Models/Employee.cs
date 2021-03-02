using Quilix.TestTask.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Quilix.TestTask.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string SecondSurname { get; set; }

        [Required]
        public DateTime EmploymentDate { get; set; }

        [Required]
        public Positions Position { get; set; }

    }
}
