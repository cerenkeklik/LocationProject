using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class EmployeeRegisterDto: RegisterBaseDto
    {
     
        public string Address { get; set; }
        public int DepartmentID { get; set; }
    }
}
