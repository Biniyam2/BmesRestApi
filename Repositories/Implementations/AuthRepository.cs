using BmesRestApi.Messages.Request.User;
using BmesRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BmesRestApi.Repositories.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AuthRepository(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        public async Task<User> FindAsync(string request, CancellationToken cancellationToken)
        {
            return await _userManager
                 .Users
                 .FirstOrDefaultAsync(u => u.Email == request, cancellationToken);
        }
        //to find the roles the user is assigned too
        public async Task<List<string>> FindUserRolesAsync(string email, CancellationToken cancellationToken)
        {
            var user = await _userManager
                 .Users
                 .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
            var roles = await _userManager.GetRolesAsync(user);
            return (List<string>)roles;

        }
        //Check if user is loged in or not
        public async Task<bool> LogInAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var result = await _signInManager.PasswordSignInAsync(
               userName: email, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(user, password); // to create the user
            if (result.Succeeded)
            {
              await _userManager.AddToRoleAsync(user, UserRole.RegisteredUser.ToString()); // assign a user to role in RegisteredUser
               var userRoles = new  RegisterRequest();
                userRoles.Roles.Add(UserRole.RegisteredUser.ToString());
            }
            //else
            //{
            //   result = (IdentityResult)result.Errors;
            //}
            return result;
        }
    }
}
