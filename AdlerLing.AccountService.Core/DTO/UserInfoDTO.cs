using System;

namespace AdlerLing.AccountService.Core.DTO
{
    public class UserInfoDTO
    {
        public Guid? UserId { get; set; }
        public int? Age{ get; set; }
        public char? Gender{ get; set; }
    }
}
