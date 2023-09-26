using System.ComponentModel.DataAnnotations;

namespace E_Shop.ViewModels
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="Enter The User Name")]
        [DataType (DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter the Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
