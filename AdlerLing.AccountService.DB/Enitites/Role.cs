using System;

namespace AdlerLing.AccountService.DB.Enitites
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
