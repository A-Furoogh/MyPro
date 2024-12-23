﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPro.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Email { get; set; }
        public required string Password { get; set; }
        public List<int> ProjectsIds { get; set; }
    }
}
