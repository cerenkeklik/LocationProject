using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class LoginDto: IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
