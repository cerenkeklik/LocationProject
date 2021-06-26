using Core.DTOs;
using Core.Entities;
using SharedKernel.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<EmployeeDetailDto> GetEmployeeDetails();
        EmployeeDetailDto GetEmployeeDetailsById(int employeeId);

    }
}
