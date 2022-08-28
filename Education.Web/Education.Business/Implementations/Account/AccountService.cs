using Education.Business.Interfaces.Account;
using Education.Business.ViewModels.Account;
using Education.Core.Entities;
using Education.Core.Interfaces;

namespace Education.Business.Implementations.Account
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Register(RegisterVM register)
        {

            AppUser user = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email,
                FullName = register.FullName,
            };
            if (await _unitOfWork.AccountRepository.Register(user, register.Password))
            //if (await _accountRe.Register(user, register.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
