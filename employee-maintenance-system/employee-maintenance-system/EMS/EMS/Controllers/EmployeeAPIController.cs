using EMS.DataAccess.Interfaces;
using EMS.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private IEmployeeRepository repo = null;

        public EmployeeAPIController(IEmployeeRepository employeeRepository)
        {
            repo = employeeRepository;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = repo?.GetAllEmployees();
            return Ok(employees);
        }

        [Route("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = repo?.GetEmployeeById(id);
            return Ok(employee);
        }

        [Route("GetEmployeeByUserName")]
        public IActionResult GetEmployeeByUserName(string userName)
        {
            var employee = repo?.GetEmployeeByUserName(userName);
            return Ok(employee);
        }

        [HttpPost("InsertEmployee")]
        public IActionResult InsertEmployee(Employee employee)
        {
            var result = new Result();
            try
            {
                result = repo.CreateNewEmployee(employee);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpPost("UpdateEmployee")]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var result=repo.UpdateEmployee(employee);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpGet("DeleteEmployee")]
        public ActionResult Delete(int id)
        {
            try
            {
                var result=repo.DeleteEmployee(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }
    }
}
