using System;
using System.ComponentModel.DataAnnotations;
namespace EMS.Model.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //[Display(Name = "First Name")]
        //[RegularExpression(pattern: "^[a-zA-Z0-9 .,]*$", ErrorMessage = "The First Name can contain only Alphabets and Numbers and the Special Characters space,.")]
        //[MaxLength(100,ErrorMessage ="Maximum Length allowed is 100 characters")]
        //[Required(ErrorMessage = "Enter the First Name")]
        public string FirstName { get; set; }

        //[Display(Name = "Middle Name")]
        //[MaxLength(100, ErrorMessage = "Maximum Length allowed is 100 characters")]
        public string MiddleName { get; set; }

        //[Display(Name = "Last Name")]
        //[MaxLength(100, ErrorMessage = "Maximum Length allowed is 100 characters")]
        //[RegularExpression(pattern: "^[a-zA-Z0-9 .,]*$", ErrorMessage = "The First Name can contain only Alphabets and Numbers and the Special Characters space,.")]
        public string LastName { get; set; }

        //[Display(Name = "User Name")]
        //[MaxLength(100, ErrorMessage = "Maximum Length allowed is 100 characters")]
        //[RegularExpression(pattern: "^[a-zA-Z0-9 .,]*$", ErrorMessage = "The First Name can contain only Alphabets and Numbers and the Special Characters space,.")]
        public string UserName { get; set; }

        //[Display(Name = "Password")]
        //[DataType(DataType.Password)]
        //[RegularExpression(pattern: @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$", ErrorMessage = "The Password can contain Minimum eight and maximum 10 characters, at least one uppercase letter, one lowercase letter, one number and one special character:")]
        public string Password { get; set; }

        //[Display(Name = "Date of Birth")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        //[Display(Name = "Date of Joining")]
        //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfJoining { get; set; }

        //[Display(Name = "Mobile")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobileNumber { get; set; }

        //[Display(Name = "Email")]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[Display(Name = "Address")]
        //[DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
