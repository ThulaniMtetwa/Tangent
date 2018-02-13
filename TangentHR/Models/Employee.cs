using System;
using System.Collections.Generic;

namespace TangentHR.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public int Id { set; get; }
        public string Id_Number { set; get; }
        public string Phone_number { set; get; }
        public string Physical_Address { set; get; }
        public string Email { set; get; }
        public bool IsEmployed { set; get; }

        public UserProfile user = new UserProfile();
        public Position position = new Position();
        public List<NextOfKin> kin = new List<NextOfKin>();
        public List<Review> review = new List<Review>();
    }
}
