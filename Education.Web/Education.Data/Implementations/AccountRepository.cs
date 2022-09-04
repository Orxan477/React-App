using Education.Core.Entities;
using Education.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Education.Data.Implementations
{
    public class AccountRepository : IAccountRepository<AppUser>
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        public AccountRepository(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 SignInManager<AppUser> signInManager,
                                 IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
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
            var checkPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!checkPassword) throw new Exception("Password incorrect");
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.IsLockedOut) throw new Exception("Profile is locked");
            if (!result.Succeeded) throw new Exception("User incorrect");
            //string token = JwtToken(user);
            //if (result.Succeeded) throw new Exception(token);
        }

        public async Task CreateRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
            }
        }
        private string JwtToken(AppUser user)
        {
            List<Claim> claims = GetClaims(user);
            SigningCredentials credentials = GetCredentials();
            JwtSecurityToken securityToken= SecurityToken(claims, credentials);
            var token=new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
        private List<Claim> GetClaims(AppUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("FullName",user.FullName)
            };
            IList<string> roles = _userManager.GetRolesAsync(user).Result;
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
            return claims;
        }
        private SigningCredentials GetCredentials()
        {
            SymmetricSecurityKey symmetric = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                                                        _configuration.GetSection("Jwt:securityKey").Value));
            SigningCredentials credentials = new SigningCredentials(symmetric, SecurityAlgorithms.HmacSha256);
            return credentials;
        }
        private JwtSecurityToken SecurityToken(List<Claim> claims, SigningCredentials credentials)
        {
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:issuer").Value,
                audience: _configuration.GetSection("Jwt:audience").Value,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );
            return securityToken;
        }
    }
}
