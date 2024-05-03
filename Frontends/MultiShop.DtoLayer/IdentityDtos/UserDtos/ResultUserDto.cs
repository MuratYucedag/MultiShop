using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.IdentityDtos.UserDtos
{
    public class ResultUserDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string id { get; set; }
        public string userName { get; set; }
        public string normalizedUserName { get; set; }
        public string email { get; set; }
        public string normalizedEmail { get; set; }
        public bool emailConfirmed { get; set; }
        public string passwordHash { get; set; }
        public string securityStamp { get; set; }
        public string concurrencyStamp { get; set; }
        public object phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public bool twoFactorEnabled { get; set; }
        public object lockoutEnd { get; set; }
        public bool lockoutEnabled { get; set; }
        public int accessFailedCount { get; set; }
    }

}