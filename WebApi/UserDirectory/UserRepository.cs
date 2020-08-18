using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;

namespace WebApi.UserDirectory
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<UserAdmin>> GetAdmins()
            => await Task.FromResult(_context.Admins);

        public async Task<IEnumerable<UserClient>> GetClients()
            => await Task.FromResult(_context.Clients);

        public async Task<User> GetUserByEmail(string email)
            => await Task.FromResult(_context.Users.FirstOrDefault(
                user => user.Email == email));

        public async Task<User> GetUserById(Guid id)
            => await Task.FromResult(_context.Users.FirstOrDefault(
                user => user.Id == id));

        public async Task<IEnumerable<User>> GetUsers()
            => await Task.FromResult(_context.Users.ToList());

        public async Task RemoveUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
