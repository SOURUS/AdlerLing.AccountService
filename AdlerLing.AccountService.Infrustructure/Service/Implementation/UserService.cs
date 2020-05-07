using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using System;

namespace AdlerLing.AccountService.Infrustructure.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL; 
        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public async Task<bool> CreateUser(CreateUserDTO user)
        {
            if (await _userDAL.CheckUserExists(user.Email))
            {
                throw new Exception($"User with Email -> {user.Email} already exists");
            }

            await _userDAL.CreateUserAsync(user);

            await _userDAL.CommitAsync();

            return true;
        }
    }
}
