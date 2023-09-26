using System.ComponentModel.DataAnnotations;

namespace E_Shop.ViewModels
{
    public class SignupViewModel
    {
        [Required(ErrorMessage ="Enter the First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Enter the Last Name")]
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage ="Enter the Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter the Phone Number")]
        [DataType(DataType.PhoneNumber),MaxLength(10,ErrorMessage ="Phone Number Must be 10 Digit")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
