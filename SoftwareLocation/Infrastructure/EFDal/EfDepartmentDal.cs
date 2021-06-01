using Core.Entities;
using Core.Interfaces;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EFDal
{
    public class EfDepartmentDal: EfEntityRepositoryBase<Department, AppDBContext>, IDepartmentDal
    {
    }
}
