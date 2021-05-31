using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IEmployeeService
    {
        void Add(Employee employee);

        void Delete(Employee employee);

        void Update(Employee employee);

        Employee GetById(int employeeId);

        List<Employee> GetAll();

        List<EmployeeDetailDto> GetEmployeeDetails();

    }
}
