using E_Shop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignupViewModel signupViewModel);
        public  Task<Microsoft.AspNetCore.Identity.SignInResult> UserLogin(LoginViewModel loginViewModel);

        public Task<String> UserName(LoginViewModel loginViewModel);

        public Task LogoutAsync();
    }
}
