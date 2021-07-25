﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opening_hours.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Info { get; set; }
    }
}
