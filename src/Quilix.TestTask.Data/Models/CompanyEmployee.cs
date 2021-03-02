﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quilix.TestTask.Data.Models
{
    public class CompanyEmployee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
