using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Department:IEntity
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public string ParallelTop { get; set; }

        public string ParallelBottom { get; set; }

        public string MeridianLeft { get; set; }

        public string MeridianRight { get; set; }




    }
}
