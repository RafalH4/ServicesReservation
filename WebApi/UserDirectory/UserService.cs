using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.UserDirectory.Dto;

namespace WebApi.UserDirectory
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;
        public UserService(IUserRepository userRepository,
            IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }
        public async Task AddAdmin(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Db contains this email ");

            var hmac = new HMACSHA512();

            var newUser = new UserAdmin
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password))
            };

            await _userRepository.AddUser(newUser);
        }

        public async Task AddClient(AddUserDto userDto)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userDto.Email);
            if (userFromDb != null)
                throw new Exception("Db contains this email ");

            var hmac = new HMACSHA512();

            var newUser = new UserClient
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(userDto.Password))
            };

            await _userRepository.AddUser(newUser);
        }

        public Task ChangePassword(ChangePasswordDto password)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ReturnUserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return _mapper.Map<IEnumerable<User>, List<ReturnUserDto>>(users);
        }
        public async Task<IEnumerable<ReturnAdminDto>> GetAdmins()
        {
            var users = await _userRepository.GetAdmins();
            return _mapper.Map<IEnumerable<UserAdmin>, List<ReturnAdminDto>>(users);
        }

        public async Task<IEnumerable<ReturnClientDto>> GetClients()
        {
            var users = await _userRepository.GetClients();
            return _mapper.Map<IEnumerable<UserClient>, List<ReturnClientDto>>(users);
        }

        public async Task<User> GetUser(Guid id)
            => await _userRepository.GetUserById(id);

        public async Task RemoveUser(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user != null)
                await _userRepository.RemoveUser(user);
        }

        public async Task UpdateUser(UpdateUserDto userDto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(UserLoginDto userLogin)
        {
            var userFromDb = await _userRepository.GetUserByEmail(userLogin.Email);
            if (userFromDb == null)
                throw new Exception("Bad email");
            if (!userFromDb.CheckPassword(userLogin.Password))
                throw new Exception("Bad password");

            return _jwtHandler.CreateToken(userFromDb);
        }


    }
}
