using Quilix.TestTask.Data.Enums;
using System;

namespace Quilix.TestTask.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string SecondName { get; set; }

        public DateTime HiringDate { get; set; }

        public PositionType Position { get; set; }
    }
}
