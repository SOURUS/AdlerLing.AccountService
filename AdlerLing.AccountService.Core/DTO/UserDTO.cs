using System;
using System.Collections.Generic;

namespace AdlerLing.AccountService.Core.DTO
{
    public class UserDTO
    {
        public Guid? UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreationDate { get; set; }
        public UserInfoDTO UserInfo { get; set; }  
        public List<RoleDTO> Roles { get; set; }
    }
}
