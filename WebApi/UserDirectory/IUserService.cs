using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory.Dto;

namespace WebApi.UserDirectory
{
    public interface IUserService
    {
        Task AddClient(AddUserDto userDto);
        Task AddAdmin(AddUserDto userDto);
        Task RemoveUser(Guid id);
        Task UpdateUser(UpdateUserDto userDto);
        Task ChangePassword(ChangePasswordDto password);
        Task<User> GetUser(Guid id);
        Task<IEnumerable<ReturnUserDto>> GetUsers();
        Task<string> Login(UserLoginDto userLogin);
    }
}
