using System;
using System.Collections.Generic;

namespace AdlerLing.AccountService.Core.DTO
{
    public class GetUserDTO
    {
        public Guid? UserId { get; set; }
        public string Email { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public UserInfoDTO UserInfo { get; set; }
    }
}
