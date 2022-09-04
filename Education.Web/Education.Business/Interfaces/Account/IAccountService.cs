using Education.Business.ViewModels.Account;

namespace Education.Business.Interfaces.Account;

public interface IAccountService
{
    Task Register(RegisterVM register);
    Task Login(LoginVM login);
    Task CreateRole();
}
