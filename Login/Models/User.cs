﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Username { get; set; }

        public int Password { get; set; }
    }
}