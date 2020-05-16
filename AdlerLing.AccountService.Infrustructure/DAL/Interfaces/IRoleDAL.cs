using AdlerLing.AccountService.Core.DTO;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.DAL.Interfaces
{
    public interface IRoleDAL : IDAL, IDisposable
    {
        Task<bool> CreateRoleAsync(RoleDTO user);
        Task<int> CheckRoleExists(string email);
    }
}
