using Microsoft.AspNetCore.Identity;

namespace E_Shop.Data.Models
{
    public class User :IdentityUser
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
