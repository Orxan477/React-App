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
        private IUnitOfWork _unitOfWork;

        public AccountRepository(UserManager<AppUser> userManager,
                                 IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Register(AppUser entity, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(entity, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, "Admin");
                await _unitOfWork.SaveChangeAsync();
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
