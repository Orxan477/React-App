using Education.Business.Interfaces.Account;
using Education.Business.Utilities;
using Education.Business.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace Education.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
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
        public async Task CreateRole()
        {
            await _accountService.CreateRole();
        }
        [HttpPost()]
        [Route("login")]
        public async Task Login(LoginVM login)
        {
            await _accountService.Login(login);
        }
    }
}
