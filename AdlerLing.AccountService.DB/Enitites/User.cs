using System;
using System.Collections.Generic;

namespace AdlerLing.AccountService.DB.Enitites
{
    public class User
    {
        public Guid user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime creation_date { get; set; }
        public bool? is_activated { get; set; }
        public UserInfo user_info { get; set; }
        public IEnumerable<Role> roles { get; set; }
    }
}
