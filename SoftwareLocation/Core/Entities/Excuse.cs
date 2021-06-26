using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Excuse:IEntity
    {
        public int ExcuseId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Time { get; set; }
        public String Description { get; set; }




    }
}
