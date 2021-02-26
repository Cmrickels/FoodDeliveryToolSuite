using System.Threading.Tasks;
using ApiGateway.Models.Entities;

namespace ApiGateway.Repositories 
{
    interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        Task<User> GetByUsername(string username);
    }
}

