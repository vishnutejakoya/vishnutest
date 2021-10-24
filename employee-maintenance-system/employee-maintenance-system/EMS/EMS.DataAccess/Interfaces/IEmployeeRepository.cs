using EMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.DataAccess.Interfaces
{
   public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByUserName(string userName);
        Result CreateNewEmployee(Employee employee);
        Result UpdateEmployee(Employee employee);
        Result DeleteEmployee(int id);
    }
}
