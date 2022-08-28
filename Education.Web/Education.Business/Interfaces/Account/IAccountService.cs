using Education.Business.ViewModels.Account;

namespace Education.Business.Interfaces.Account;

public interface IAccountService
{
    Task<bool> Register(RegisterVM register);
}
