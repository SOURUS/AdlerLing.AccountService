using System;

namespace AdlerLing.AccountService.DB.Enitites
{
    public class UserInfo
    {
        public Guid user_id { get; set; }
        public int? age { get; set; }
        public char? gender { get; set; }
        public DateTime? ceation_date { get; set; }
    }
}
