using Core.Entities;
using Core.Interfaces;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DTOs;

namespace Infrastructure.EFDal
{
    public class EfInspectionDal : EfEntityRepositoryBase<Inspection, AppDBContext>, IInspectionDal
    {
        public List<InspectionDetailDto> GetInspectionDetails()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var result = from i in context.Inspections
                             join e in context.Employees
                             on i.EmployeeID equals e.EmployeeID
                             select new InspectionDetailDto
                             {
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 Parallel = i.Parallel,
                                 Meridian = i.Meridian,
                                 checkIsInLocation = i.CheckIsInLocation
                                
                             };

                return result.ToList();
            }
        }
    }
}
