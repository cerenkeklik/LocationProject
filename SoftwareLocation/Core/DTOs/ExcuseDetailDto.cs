using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class ExcuseDetailDto :IDto
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }

    }
}
