using Education.Business.ViewModels.Account;
using Education.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            AppUser newUser = new AppUser
            {
                FullName = register.FullName,
                UserName = register.U,
                Email = "orxan_qanbarov@mail.ru"
            };

        }
    }
}
