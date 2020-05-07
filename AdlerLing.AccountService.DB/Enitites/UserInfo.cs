using System;

namespace AdlerLing.AccountService.DB.Enitites
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public UInt16? Age { get; set; }
        public char Gender { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
