using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void Add(Department department)
        {
            _departmentDal.Add(department);
        }

        public void Delete(Department department)
        {
            _departmentDal.Delete(department);
        }

        public List<Department> GetAll()
        {
            var result = _departmentDal.GetAll();
            return result;
        }

        public Department GetById(int departmentId)
        {
            var result = _departmentDal.Get(d => d.DepartmentID == departmentId);
            return result;
        }

        public void Update(Department department)
        {
            _departmentDal.Update(department);
        }
    }
}
