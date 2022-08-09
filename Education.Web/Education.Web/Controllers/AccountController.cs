using Education.Business.ViewModels.Account;
using Education.Core.Entities;
using Education.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private IUnitOfWork _unitOfWork;

        public AccountController(UserManager<AppUser> userManager,
                                 IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        [HttpPost()]
        public async Task Register(RegisterVM register)
        {
            AppUser newUser = new AppUser
            {
                FullName = register.FullName,
                UserName = register.UserName,
                Email = register.Email
            };
           IdentityResult result = await _userManager.CreateAsync(newUser,register.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Admin");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
