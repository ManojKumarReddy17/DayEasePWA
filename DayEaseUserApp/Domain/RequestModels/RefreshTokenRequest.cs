﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
    }
}
