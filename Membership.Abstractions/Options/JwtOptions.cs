﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Options
{
    public class JwtOptions
    {
        public const string SectionKey = "Jwt";
        public string SecurityKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public int ExpireInMinutes { get; set; }
        public int ClockSkewInMinutes { get; set; }
        public int RefreshTokenExpireInMinutes { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifeTime { get; set; }
        public bool ValidateIssuerSigninKey { get; set; }

        public JwtOptions()
        {
            
        }
    }
}