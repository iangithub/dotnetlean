﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DataEfCore.EntityModels
{
    public partial class Courseschedule
    {
        public Guid Id { get; set; }
        public Guid Courseid { get; set; }
        public Guid Teacherid { get; set; }
        public DateTime Sdate { get; set; }
        public DateTime Edate { get; set; }
        public string Location { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}