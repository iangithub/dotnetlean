﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataEfCore.EntityModels
{
    public partial class Course
    {
        public Course()
        {
            Courseschedule = new HashSet<Courseschedule>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Times { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Courseschedule> Courseschedule { get; set; }
    }
}