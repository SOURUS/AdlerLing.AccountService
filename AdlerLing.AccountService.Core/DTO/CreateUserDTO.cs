using System.Collections.Generic;

namespace AdlerLing.AccountService.Core.DTO
{
    public class CreateUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<CreateUserAddRoleDTO> Roles { get; } = new List<CreateUserAddRoleDTO>();
    }
}
