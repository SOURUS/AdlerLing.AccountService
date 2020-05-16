using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Core.Transfering;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Service.Interfaces
{
    public interface IUserService
    {
        Task<Result<Guid>> CreateUser(UserDTO user);
        Task<Result<UserDTO>> GetUser(Guid userId);
    }
}
