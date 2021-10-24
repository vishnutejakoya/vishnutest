using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.DataAccess.Interfaces;
using EMS.Model.Models;
using EMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    /// <summary>
    /// Employee Controller. Uses MVC Concept
    /// </summary>
    public class EmployeeController : Controller
    {
        private IEmployeeRepository repo = null;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            repo = employeeRepository;
        }
        // GET: Employee
        /// <summary>
        /// Get All the Employees
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var employees = repo?.GetAllEmployees();
            var employeeViewModel = new EmployeeViewModel
            {
                Employees = employees,
                Employee = new Employee()
            };
            return View(employeeViewModel);
        }

        /// <summary>
        /// Get Employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        /// <summary>
        /// Create an Employee
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public ActionResult Create(string errorMessage = null)
        {
            if (!string.IsNullOrEmpty(errorMessage))
                ViewBag.ErrorMessage = errorMessage;

            return View();
        }

        // POST: Employee/Create
        /// <summary>
        /// Create an Employee Record
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            var result = new Result();
            try
            {
                result = repo.CreateNewEmployee(employee);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToActionPermanent("Create", new { errorMessage = ex.Message });
            }
        }

        // GET: Employee/Edit/5
        /// <summary>
        /// Edit an Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var employee = repo.GetEmployeeById(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        /// <summary>
        /// Update the Employee Record.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                repo.UpdateEmployee(employee);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return RedirectToActionPermanent("Edit", new { id = id });
            }
        }

        /// <summary>
        /// Delete an Employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                repo.DeleteEmployee(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet()]
        [Route("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = repo?.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet()]
        [Route("/GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = repo?.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpGet()]
        [Route("/GetEmployeeByUserName/{userName}")]
        public IActionResult GetEmployeeByUserName(string userName)
        {
            var employee = repo?.GetEmployeeByUserName(userName);
            return Ok(employee);
        }

        [HttpPost()]
        [Route("/InsertEmployee")]
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

        [HttpPost]
        [Route("/UpdateEmployee")]
        public ActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var result = repo.UpdateEmployee(employee);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }

        [HttpGet()]
        [Route("/DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = repo.DeleteEmployee(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }
    }
}