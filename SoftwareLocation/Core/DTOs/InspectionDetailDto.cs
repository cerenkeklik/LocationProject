using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs
{
    public class InspectionDetailDto: IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Meridian { get; set; }
        public string Parallel { get; set; }
        public bool checkIsInLocation { get; set; }
    }
}
