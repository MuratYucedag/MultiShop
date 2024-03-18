using Microsoft.VisualBasic;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "MultiShop..0102030405Asp.NetCore6.0.28*/+-";
        public const int Expire = 60;
    }
}
