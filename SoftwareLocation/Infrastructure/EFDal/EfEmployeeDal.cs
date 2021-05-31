using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infrastructure.EFDal
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, AppDBContext>, IEmployeeDal
    {
        public List<EmployeeDetailDto> GetEmployeeDetails()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var result = from e in context.Employees
                             join d in context.Departments
                             on e.DepartmentID equals d.DepartmentID
                             select new EmployeeDetailDto
                             {
                                 FirstName = e.FirstName,
                                 LastName = e.LastName,
                                 DateOfBirth = e.DateOfBirth,
                                 Address = e.Address,
                                 Gender = e.Gender,
                                 Email = e.Email,
                                 Department = d.DepartmentName
                             };

                return result.ToList();
            }
        }
    }
}
