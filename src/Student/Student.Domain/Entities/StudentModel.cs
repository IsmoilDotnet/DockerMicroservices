﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.Entities
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
