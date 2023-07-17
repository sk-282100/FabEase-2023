﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
    }
}
