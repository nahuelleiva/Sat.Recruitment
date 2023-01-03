﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace Sat.Recruitment.Api.DTO
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
