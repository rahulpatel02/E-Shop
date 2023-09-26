using E_Shop.Data.Interfaces;
using E_Shop.Data.Models;
using E_Shop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;   
        }

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Signup(SignupViewModel signupViewModel)
        {
            if(ModelState.IsValid)
            {
             var result=  await _accountRepository.CreateUser(signupViewModel);
                if (result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                        
                    }
                }
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ViewBag.Login = false;
            if (ModelState.IsValid)
            {
                 var result = await _accountRepository.UserLogin(loginViewModel);
                if (result.Succeeded)
                {
                    TempData["Tag"] = await _accountRepository.UserName(loginViewModel);
                    ViewBag.Login = true;
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("","Invalid Credential");

            }
            return View(loginViewModel);
        }
    }
}
