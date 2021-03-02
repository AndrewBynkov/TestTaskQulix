using Quilix.TestTask.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quilix.TestTask.DataAppWeb.ViewModels
{
    public class Employee
    {
        [Required]
        [Display(Name = "Имя сотрудника")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Отчество")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Дата принятия на работу")]
        public DateTime HiringDate { get; set; }

        [Required]
        [Display(Name = "Должность")]
        public PositionType Position { get; set; }
    }
}
