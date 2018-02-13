using System;
namespace TangentHR.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
        }
        public int Id { set; get; }
        public string Username { set; get; }
        public string Email { set; get; }
        public string First_name { set; get; }
        public string Last_name { set; get; }
        public bool Is_active { set; get; }
        public bool Is_staff { set; get; }
        public bool Is_superuser { set; get; }
    }
}
