using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
