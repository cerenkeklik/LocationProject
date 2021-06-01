using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IDepartmentService
    {
        void Add(Department department);

        void Delete(Department department);

        void Update(Department department);

        Department GetById(int departmentId);

        List<Department> GetAll();
    }
}
