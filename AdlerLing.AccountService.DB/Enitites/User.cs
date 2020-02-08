using System;
using System.Collections.Generic;

namespace AdlerLing.AccountService.DB.Enitites
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActivated { get; set; }
        public List<Role> Roles { get; } = new List<Role>();
    }
}
