using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Inspection: IEntity
    {
        public int InspectionID { get; set; }

        public int EmployeeID { get; set; }

        public string Meridian { get; set; }

        public string Parallel { get; set; }

        public Boolean CheckIsInLocation { get; set; }
    }
}
