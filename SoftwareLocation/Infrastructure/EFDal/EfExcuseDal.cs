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
    public class EfExcuseDal: EfEntityRepositoryBase<Excuse, AppDBContext>, IExcuseDal
    {
        public List<ExcuseDetailDto> GetExcuseDetails()
        {
            using (AppDBContext context = new AppDBContext())
            {
                var result = from em in context.Employees
                             join e in context.Excuses
                             on em.EmployeeID equals e.EmployeeId
                             join d in context.Departments
                             on em.DepartmentID equals d.DepartmentID
                             select new ExcuseDetailDto
                             {
                                 FirstName = em.FirstName,
                                 LastName=em.LastName,
                                 Department=d.DepartmentName,
                                 Description=e.Description,
                                 Time=e.Time


                             };

                return result.ToList();
            }
        }
        public ExcuseDetailDto GetExcuseDetailsById(int excuseId)
        {
            using (AppDBContext context = new AppDBContext())
            {
                var result = from em in context.Employees
                             join e in context.Excuses
                             on em.EmployeeID equals e.EmployeeId
                             join d in context.Departments
                             on em.DepartmentID equals d.DepartmentID
                             where e.ExcuseId==excuseId
                             select new ExcuseDetailDto
                            
                             {
                                 FirstName = em.FirstName,
                                 LastName = em.LastName,
                                 Department = d.DepartmentName,
                                 Description = e.Description,
                                 Time = e.Time


                             };

                return result.Single<ExcuseDetailDto>();
            }
        }

        
    }



}

