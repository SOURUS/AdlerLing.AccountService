using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using System.Threading.Tasks;
using AdlerLing.AccountService.Core.Transfering;
using AdlerLing.AccountService.Core.Enums;
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

        public async Task<Result> CreateUser(CreateUserDTO user)
        {
            try
            {
                if (await _userDAL.CheckUserExists(user.Email) != 0)
                {
                    return Result.CreateFailure(ErrorCodeEnum.UserWithEmailExists);
                }

                await _userDAL.CreateUserAsync(user);
                
                await _userDAL.CommitAsync();

                return Result.CreateSuccess();
            }

            catch (Exception ex)
            {
                return Result.CreateFailure(ex);
            }
        }
    }
}
