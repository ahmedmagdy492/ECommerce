using E_Commerce.Models;
using System.Threading.Tasks;

namespace E_Commerce.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
    }
}