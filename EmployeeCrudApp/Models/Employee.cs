using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudApp.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter First name")]
        [MinLength(5, ErrorMessage = "The First Name must be atleast 5 characters")]
        [MaxLength(15, ErrorMessage = "The First Name cannot be more than 15 characters")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last name")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "The Last Name should be between 5 to 15 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "DOB Required")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DOB { get; set; }
        
        [Required(ErrorMessage = "Phone Number Required")]
        [MaxLength(10, ErrorMessage = "Do not enter more than 10 numbers")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter PhoneNumber as 0123456789, 012-345-6789, (012)-345-6789.")]
        public string? MobileNumber { get; set; }
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string? AddressLine1 { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(50, ErrorMessage = "Do not enter more than 50 characters")]
        public string? AddressLine2 { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        [MaxLength(20, ErrorMessage = "Do not enter more than 20 characters")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please enter PostalCode")]
        [DataType(DataType.PostalCode)]
        [MaxLength(10, ErrorMessage = "Do not enter more than 10 digits")]
        public string? PostalCode{ get; set; }
        [Required(ErrorMessage = "Please enter Country")]
        [MaxLength(25, ErrorMessage = "Do not enter more than 25 characters")]
        public string? Country { get; set; }
       


    }
}
