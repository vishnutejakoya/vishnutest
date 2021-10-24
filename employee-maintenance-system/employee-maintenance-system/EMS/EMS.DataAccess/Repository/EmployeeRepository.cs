using EMS.DataAccess.Interfaces;
using EMS.Model.Models;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Text;

namespace EMS.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region [Private Variables]
        private string _sqlConnection;
        #endregion

        #region [Constructor]
        public EmployeeRepository(string connectionString)
        {
            _sqlConnection = connectionString;
        }
        #endregion

        #region [Repository Methods]
        public Result CreateNewEmployee(Employee employee)
        {
            using (var connection = Connect())
            {
                var query = Constants.Procedures.SP_ADD_EMPLOYEE
                                               .Replace("{emp_first_name}", employee.FirstName)
                                               .Replace("{emp_middle_name}", employee.MiddleName)
                                               .Replace("{emp_last_name}", employee.LastName)
                                               .Replace("{emp_username}", employee.UserName)
                                               .Replace("{emp_password}", employee.Password)
                                               .Replace("{emp_address}", employee.Address)
                                               .Replace("{emp_createdby}", "1")
                                               .Replace("{emp_mobile}", employee.MobileNumber)
                                               .Replace("{emp_email}", employee.Email);

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();

                    return new Result
                    {
                        IsSuccess=true
                    };
                }
            }
        }

        public Result DeleteEmployee(int empId)
        {
            using (var connection = Connect())
            {
                var query = Constants.Procedures.SP_DELETE_EMPLOYEE
                                               .Replace("{emp_id}", empId.ToString());
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();

                    return new Result
                    {
                        IsSuccess=true
                    };
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var lstEmployee = new List<Employee>();
            using (var connection = Connect())
            {
                using (var command = new NpgsqlCommand(Constants.Procedures.SP_GET_ALL_EMPLOYEE, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        lstEmployee.Add(new Employee
                        {
                            Id = reader["emp_id"] != DBNull.Value ? Convert.ToInt32(reader["emp_id"]) : 0,
                            FirstName = reader["emp_first_name"] != DBNull.Value ? Convert.ToString(reader["emp_first_name"]) : string.Empty,
                            MiddleName = reader["emp_middle_name"] != DBNull.Value ? Convert.ToString(reader["emp_middle_name"]) : string.Empty,
                            LastName = reader["emp_last_name"] != DBNull.Value ? Convert.ToString(reader["emp_last_name"]) : string.Empty,
                            //DateOfBirth = reader["emp_dob"] != DBNull.Value ? Convert.ToDateTime(reader["emp_dob"]) : DateTime.MinValue,
                            //DateOfJoining = reader["emp_doj"] != DBNull.Value ? Convert.ToDateTime(reader["emp_doj"]) : DateTime.MinValue,
                            UserName = reader["emp_username"] != DBNull.Value ? Convert.ToString(reader["emp_username"]) : string.Empty,
                            Password = reader["emp_password"] != DBNull.Value ? Convert.ToString(reader["emp_password"]) : string.Empty,
                            MobileNumber = reader["emp_mobile"] != DBNull.Value ? Convert.ToString(reader["emp_mobile"]) : string.Empty,
                            Email = reader["emp_email"] != DBNull.Value ? Convert.ToString(reader["emp_email"]) : string.Empty,
                            Address = reader["emp_address"] != DBNull.Value ? Convert.ToString(reader["emp_address"]) : string.Empty,
                        });
                    }
                }
            }
            return lstEmployee;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = new Employee();
            using (var connection = Connect())
            {
                using (var command = new NpgsqlCommand(Constants.Procedures.SP_GET_EMPLOYEE.Replace("{empId}",id.ToString()), connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = reader["emp_id"] != DBNull.Value ? Convert.ToInt32(reader["emp_id"]) : 0,
                            FirstName = reader["emp_first_name"] != DBNull.Value ? Convert.ToString(reader["emp_first_name"]) : string.Empty,
                            MiddleName = reader["emp_middle_name"] != DBNull.Value ? Convert.ToString(reader["emp_middle_name"]) : string.Empty,
                            LastName = reader["emp_last_name"] != DBNull.Value ? Convert.ToString(reader["emp_last_name"]) : string.Empty,
                            //DateOfBirth = reader["emp_dob"] != DBNull.Value ? Convert.ToDateTime(reader["emp_dob"]) : DateTime.MinValue,
                            //DateOfJoining = reader["emp_doj"] != DBNull.Value ? Convert.ToDateTime(reader["emp_doj"]) : DateTime.MinValue,
                            UserName = reader["emp_username"] != DBNull.Value ? Convert.ToString(reader["emp_username"]) : string.Empty,
                            Password = reader["emp_password"] != DBNull.Value ? Convert.ToString(reader["emp_password"]) : string.Empty,
                            MobileNumber = reader["emp_mobile"] != DBNull.Value ? Convert.ToString(reader["emp_mobile"]) : string.Empty,
                            Email = reader["emp_email"] != DBNull.Value ? Convert.ToString(reader["emp_email"]) : string.Empty,
                            Address = reader["emp_address"] != DBNull.Value ? Convert.ToString(reader["emp_address"]) : string.Empty,
                        };
                    }
                }
            }
            return employee;
        }

        public Employee GetEmployeeByUserName(string userName)
        {
            var employee = new Employee();
            using (var connection = Connect())
            {
                using (var command = new NpgsqlCommand(Constants.Procedures.SP_GET_EMPLOYEE_BY_USERNAME.Replace("{emp_username}", userName.ToString()), connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        employee = new Employee
                        {
                            Id = reader["emp_id"] != DBNull.Value ? Convert.ToInt32(reader["emp_id"]) : 0,
                            FirstName = reader["emp_first_name"] != DBNull.Value ? Convert.ToString(reader["emp_first_name"]) : string.Empty,
                            MiddleName = reader["emp_middle_name"] != DBNull.Value ? Convert.ToString(reader["emp_middle_name"]) : string.Empty,
                            LastName = reader["emp_last_name"] != DBNull.Value ? Convert.ToString(reader["emp_last_name"]) : string.Empty,
                            //DateOfBirth = reader["emp_dob"] != DBNull.Value ? Convert.ToDateTime(reader["emp_dob"]) : DateTime.MinValue,
                            //DateOfJoining = reader["emp_doj"] != DBNull.Value ? Convert.ToDateTime(reader["emp_doj"]) : DateTime.MinValue,
                            UserName = reader["emp_username"] != DBNull.Value ? Convert.ToString(reader["emp_username"]) : string.Empty,
                            Password = reader["emp_password"] != DBNull.Value ? Convert.ToString(reader["emp_password"]) : string.Empty,
                            MobileNumber = reader["emp_mobile"] != DBNull.Value ? Convert.ToString(reader["emp_mobile"]) : string.Empty,
                            Email = reader["emp_email"] != DBNull.Value ? Convert.ToString(reader["emp_email"]) : string.Empty,
                            Address = reader["emp_address"] != DBNull.Value ? Convert.ToString(reader["emp_address"]) : string.Empty,
                        };
                    }
                }
            }
            return employee;
        }

        public Result UpdateEmployee(Employee employee)
        {
            using (var connection = Connect())
            {
                var query = Constants.Procedures.SP_UPDATE_EMPLOYEE
                                               .Replace("{emp_first_name}", employee.FirstName)
                                               .Replace("{emp_middle_name}", employee.MiddleName)
                                               .Replace("{emp_last_name}", employee.LastName)
                                               .Replace("{emp_username}", employee.UserName)
                                               .Replace("{emp_password}", employee.Password)
                                               .Replace("{emp_address}", employee.Address)
                                               .Replace("{emp_modifiedby}", "1")
                                               .Replace("{emp_mobile}", employee.MobileNumber)
                                               .Replace("{emp_email}", employee.Email)
                                               .Replace("{emp_id}", employee.Id.ToString());

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    connection.Open();
                    command.ExecuteNonQuery();

                    return new Result
                    {
                        IsSuccess = true
                    };
                }
            }
        }
        #endregion

        #region [Private Methods]

        private NpgsqlConnection Connect()
        {
            return new NpgsqlConnection(_sqlConnection);
        }
        #endregion
    }
}
