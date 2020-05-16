using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using AdlerLing.AccountService.Core.Transfering;
using AdlerLing.AccountService.Core.Enums;
using System;
using AdlerLing.AccountService.Infrustructure.Helpers;

namespace AdlerLing.AccountService.Infrustructure.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserDAL _userDAL; 
        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public async Task<Result<Guid>> CreateUser(UserDTO user)
        {
            try
            {
                if (await _userDAL.CheckUserExists(user.Email) != 0)
                {
                    return Result.CreateFailure<Guid>(ErrorCodeEnum.UserWithEmailExists);
                }

                var userId = await _userDAL.CreateUserAsync(user);
                
                await _userDAL.CommitAsync();

                return Result.CreateSuccess(userId);
            }

            catch (Exception ex)
            {
                return Result.CreateFailure<Guid>(ex);
            }
        }

        public async Task<Result<UserDTO>> GetUser(Guid userId)
        {
            try
            {
                if (await _userDAL.CheckUserById(userId) == 0)
                {
                    return Result.CreateFailure<UserDTO>(ErrorCodeEnum.UserWithIdDoesntExist);
                }

                var user = await _userDAL.GetUser(userId);

                await _userDAL.CommitAsync();

                var userDTO = Mapping.Mapper.Map<UserDTO>(user);

                return Result.CreateSuccess(userDTO);
            }

            catch (Exception ex)
            {
                return Result.CreateFailure<UserDTO>(ex);
            }
        }
    }
}
