using Education.Core.Entities;
using Education.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Implementations
{
    public class AccountRepository: IAccountRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;

        public AccountRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Register(AppUser entity, string password)
        {
            AppUser user =await  _userManager.FindByEmailAsync(entity.Email);
            if (user != null) throw new Exception("mail movcddur");
            IdentityResult identityResult = await _userManager.CreateAsync(entity, password);
            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, "Admin");
            }
            throw new Exception("Problem var");
        }

        public Task<bool> Login(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
