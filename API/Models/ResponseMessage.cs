﻿using System;
namespace API.Models
{
    public class ResponseMessage
    {
        public string Status { get; set; }
        public User Results { get; set; }
        public string Message { get; set; }
    }
}
