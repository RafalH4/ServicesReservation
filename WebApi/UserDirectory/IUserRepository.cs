using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UserDirectory
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task RemoveUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<UserAdmin>> GetAdmins();
        Task<IEnumerable<UserClient>> GetClients();
    }
}
