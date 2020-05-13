using AdlerLing.AccountService.Core.DTO;
using AdlerLing.AccountService.Core.Transfering;
using AdlerLing.AccountService.Infrustructure.DAL.Interfaces;
using AdlerLing.AccountService.Infrustructure.Service.Interfaces;
using AdlerLing.AccountService.Core.Enums;
using System;
using System.Threading.Tasks;

namespace AdlerLing.AccountService.Infrustructure.Service.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleDAL _roleDAL;
        public RoleService(IRoleDAL roleDAL)
        {
            _roleDAL = roleDAL;
        }

        public async Task<Result> CreateRole(CreateRoleDTO role)
        {
            try
            {
                if (await _roleDAL.CheckRoleExists(role.Name) != 0)
                {
                    return Result.CreateFailure(ErrorCodeEnum.RoleNameAlreadyExists);
                }

                await _roleDAL.CreateRoleAsync(role);

                await _roleDAL.CommitAsync();

                return Result.CreateSuccess();
            }

            catch (Exception ex)
            {
                return Result.CreateFailure(ex);
            }
        }
    }
}
