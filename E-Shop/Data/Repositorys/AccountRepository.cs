using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using E_Shop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace E_Shop.Data.Repositorys
{
    public class AccountRepository : IAccountRepository
    {

        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public async Task<IdentityResult> CreateUser(SignupViewModel signupViewModel)
        {
            var user = new User()
            {
                FirstName = signupViewModel.FirstName,
                LastName = signupViewModel.LastName,
                Email = signupViewModel.Email,
                UserName=signupViewModel.Email,
                PhoneNumber = signupViewModel.PhoneNumber,
                CreatedDate = signupViewModel.CreatedDate,
            };
          var result= await _userManager.CreateAsync(user,signupViewModel.Password);
            return result; 
        }

      

        public async Task<SignInResult> UserLogin(LoginViewModel loginViewModel)
        {            
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password,false,false);

                return result;


        }

        public async Task<String>  UserName(LoginViewModel loginViewModel)
        {
                var userName= await  _userManager.FindByEmailAsync(loginViewModel.UserName);
                if (userName != null) {
                string name=userName.FirstName+userName.LastName;
                return name;

              }
            return "false";
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
