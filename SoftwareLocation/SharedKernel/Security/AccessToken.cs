using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int employeeId { get; set; }
    }
}
