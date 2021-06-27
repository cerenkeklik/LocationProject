using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Authority:IEntity
    {
        public int AuthorityID { get; set; }

        public string Token { get; set; }

    }
}
