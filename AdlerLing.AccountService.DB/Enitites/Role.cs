using System;

namespace AdlerLing.AccountService.DB.Enitites
{
    public class Role
    {
        public int role_id { get; set; }
        public string name { get; set; }
        public DateTime creation_date { get; set; }
    }
}
