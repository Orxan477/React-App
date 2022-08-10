using Education.Business.Utilities;
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
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
                                 IUnitOfWork unitOfWork,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }
        [HttpPost()]
        [Route("register")]
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
        [HttpPost()]
        [Route("createRole")]
        public async Task<string> CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            return "Hazirdir";
        }
        [HttpPost()]
        [Route("login")]
        public async Task<string> Login(LoginVM login)
        {
            
            return "Hele Hazirlanir";
        }
    }
}
