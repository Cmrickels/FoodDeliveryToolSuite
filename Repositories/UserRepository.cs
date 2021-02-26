using Microsoft.AspNetCore.Identity;
using ApiGateway.Models.Entities;
using System.Threading.Tasks;

namespace ApiGateway.Repositories
{
    public class UserRepository: IUserRepository
    {
        UserManager<User> _userManager;
        UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        




    }
}