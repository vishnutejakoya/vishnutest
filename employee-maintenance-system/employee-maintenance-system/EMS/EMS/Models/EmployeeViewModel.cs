using EMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Models
{
    /// <summary>
    /// Employee View Model
    /// </summary>
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }

        public List<ErrorItem> ErrorItems { get; set; }
    }
}
