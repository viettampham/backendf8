using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using backendf8.Models;
using backendf8.Models.RequestModels;
using backendf8.Models.ResponseModels;
using backendf8.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace backendf8.Services.Impl
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly MasterDbContext _context;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration, MasterDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
        
        
        
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user ==null)
            {
                throw new Exception("Username is not exsist");
            }

            var loginresponse = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!loginresponse)
            {
                throw new Exception("Tai khoan hoac mat khau sai");
            }

            var token = await GenerateTokenJWTByUser(user);
            return new LoginResponse
            {   
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<bool> Registration(RegistrationUser request)
        {
            if (request.Username == null)
            {
                throw new Exception("Username is not empty");
            }

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = request.Username,
                Name = request.Name,
                Address = request.Address,
                Email = request.Email
            };
            var newuser = await _userManager.CreateAsync(user, request.Password);
            if (newuser.Succeeded)
            {
                return true;
            }

            return false;
        }

        public List<UserResponse> GetListUser()
        {
            var listUser = _context.Users.Select(user => new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Address = user.Address,
                Email = user.Email
                
            }).ToList();
            return listUser;
        }

        public UserResponse DeleteUser(Guid id)
        {
            var targetUser = _context.Users.FirstOrDefault(user => user.Id == id);
            if (targetUser==null)
            {
                throw new Exception("This user not exsist");
            }

            _context.Remove(targetUser);
            _context.SaveChanges();
            return new UserResponse
            {
                Id = targetUser.Id,
                UserName = targetUser.UserName,
                Name = targetUser.Name,
                Address = targetUser.Address,
                Email = targetUser.Email

            };
        }
        
        
        
        private async Task<JwtSecurityToken> GenerateTokenJWTByUser(ApplicationUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (string role in userRoles)
            {
                var roleData = await _roleManager.FindByNameAsync(role);
            }
            authClaims.Add(new Claim(ClaimTypes.Role, "manyRole"));

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DefaultApplication.SecretKey));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

    }
}