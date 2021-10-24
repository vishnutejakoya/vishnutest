namespace EMS.Model.Models
{
    public class Constants
    {
        public class Procedures
        {
            public const string SP_GET_EMPLOYEE = @"select eo.emp_id,
                                                           eo.emp_first_name,
                                                           eo.emp_middle_name,
                                                           eo.emp_last_name,
                                                           eo.emp_username,
                                                           eo.emp_password,
                                                           eo.emp_address,
                                                           eo.emp_mobile,
                                                           eo.emp_email
                                                      from employee eo WHERE eo.emp_id={empId};";

            public const string SP_GET_EMPLOYEE_BY_USERNAME = @"select eo.emp_id,
                                                           eo.emp_first_name,
                                                           eo.emp_middle_name,
                                                           eo.emp_last_name,
                                                           eo.emp_username,
                                                           eo.emp_password,
                                                           eo.emp_address,
                                                           eo.emp_mobile,
                                                           eo.emp_email
                                                      from employee eo WHERE eo.emp_username= '{emp_username}';";

            public const string SP_GET_ALL_EMPLOYEE = @"select eo.emp_id,
                                                           eo.emp_first_name,
                                                           eo.emp_middle_name,
                                                           eo.emp_last_name,
                                                           eo.emp_username,
                                                           eo.emp_password,
                                                           eo.emp_address,
                                                           eo.emp_mobile,
                                                           eo.emp_email
                                                      from employee eo;";

            public const string SP_ADD_EMPLOYEE = @"INSERT INTO employee
                                                                (
                                                                    emp_first_name,
                                                                    emp_middle_name,
                                                                    emp_last_name,
                                                                    emp_username,
                                                                    emp_password,
                                                                    emp_address,
                                                                    emp_createdby,
                                                                    emp_mobile,
                                                                    emp_email
                                                                )
                                                        VALUES
                                                                (
                                                                    '{emp_first_name}',
                                                                    '{emp_middle_name}',
                                                                    '{emp_last_name}',
                                                                    '{emp_username}',
                                                                    '{emp_password}',
                                                                    '{emp_address}',
                                                                     {emp_createdby},
                                                                    '{emp_mobile}',
                                                                    '{emp_email}'
                                                                );
                                                ";

            public const string SP_UPDATE_EMPLOYEE = @"   UPDATE    employee
                                                             SET    emp_first_name      =   '{emp_first_name}',
                                                                    emp_middle_name     =   '{emp_middle_name}',
                                                                    emp_last_name       =   '{emp_last_name}',
                                                                    emp_username        =   '{emp_username}',
                                                                    emp_password        =   '{emp_password}',
                                                                    emp_address         =   '{emp_address}',
                                                                    emp_modifiedby      =    {emp_modifiedby},
                                                                    emp_mobile          =   '{emp_mobile}',
                                                                    emp_email           =   '{emp_email}'
                                                          WHERE     emp_id              =    {emp_id};";
            
            public const string SP_DELETE_EMPLOYEE = "DELETE FROM employee WHERE emp_id =   {emp_id};";
        }

        public enum Mode
        {
            Add=1,
            Modify=2,
            Delete=3
        }
    }

    public class Result
    {
        public int Id { get; set; }
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
