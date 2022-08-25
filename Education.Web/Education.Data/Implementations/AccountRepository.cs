using Education.Core.Entities;
using Education.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Implementations
{
    internal class AccountRepository : IAccountRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;

        public AccountRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Register(AppUser entity, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(entity, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, "Admin");
                return true;
            }
            return false;
        }
        public Task<bool> Login(AppUser entity)
        {
            throw new NotImplementedException();
        }

    }
}
