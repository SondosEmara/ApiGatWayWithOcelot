using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtConfiguration
{
    public record JwtConfigData
    {
        public static readonly string ValidIssuer = "https://localhost:7077/";
        public static readonly string ValidAudience = "https://localhost:7077/";
        public static readonly string Key = "DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4";
    }
}
