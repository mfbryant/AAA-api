using System;
namespace api.models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public Boolean Executive { get; set; }
        public Boolean Officer { get; set; }
        public int OrgId { get; set; }
    }
}