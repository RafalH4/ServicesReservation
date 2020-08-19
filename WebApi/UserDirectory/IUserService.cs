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
        Task UpdateUser(UpdateUserDtoByAdmin userDto);
        Task UpdateUser(UpdateUserDto userDto);
        Task ChangePassword(ChangePasswordDto password);
        Task<ReturnUserDto> GetUser(Guid id);
        Task<IEnumerable<ReturnUserDto>> GetUsers();
        Task<IEnumerable<ReturnAdminDto>> GetAdmins();
        Task<IEnumerable<ReturnClientDto>> GetClients();
        Task<string> Login(UserLoginDto userLogin);
    }
}
