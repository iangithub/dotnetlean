// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataEfCore.EntityModels
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courseschedule = new HashSet<Courseschedule>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<Courseschedule> Courseschedule { get; set; }
    }
}