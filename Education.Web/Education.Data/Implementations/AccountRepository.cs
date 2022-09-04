using Education.Core.Entities;
using Education.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Education.Data.Implementations
{
    public class AccountRepository : IAccountRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountRepository(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task Register(AppUser entity, string password)
        {
            AppUser user = await _userManager.FindByEmailAsync(entity.Email);
            if (user != null) throw new Exception("mail movcddur");
            IdentityResult identityResult = await _userManager.CreateAsync(entity, password);
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, "Admin");
            }
            throw new Exception("Problem var");
        }

        public async Task Login(string email, string password)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user is null) throw new Exception("Not Found");
            if (user.IsActive == false) throw new Exception("Profile no active");
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.IsLockedOut) throw new Exception("Profile is locked");
            if (!result.Succeeded) throw new Exception("User or Password incorrect");
        }

        public async Task CreateRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
            }
        }
    }
}
