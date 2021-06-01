using Core.Entities;
using SharedKernel.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IManagerDal: IEntityRepository<Manager>
    {
    }
}
