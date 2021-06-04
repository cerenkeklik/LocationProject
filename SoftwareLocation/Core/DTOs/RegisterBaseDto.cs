using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
   public class RegisterBaseDto: IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
    }
}
