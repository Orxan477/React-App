using Education.Business.Interfaces.Account;
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
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<AppUser> _signInManager;
        private IAccountService _accountService;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager,
                                 IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }
        [HttpPost()]
        [Route("register")]
        public async Task Register(RegisterVM register)
        {
            await _accountService.Register(register);
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
        public async Task<ActionResult> Login(LoginVM login)
        {
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user is null) return NotFound();
            if (user.IsActive == false) return BadRequest("Profile no active");
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
            if (result.IsLockedOut) return BadRequest("Profile is locked");
            if (!result.Succeeded) return BadRequest("User or Password incorrect");
            return Ok("Giris alindi");
        }
    }
}
