using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class InspectionManager : IInspectionService
    {
        IInspectionDal _inspectionDal;
        IDepartmentService _departmentService;
        IEmployeeService _employeeService;


        public InspectionManager(IInspectionDal inspectionDal, IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _inspectionDal = inspectionDal;
            _departmentService = departmentService;
            _employeeService = employeeService;

        }

        public void Add(Inspection inspection)
        {
            _inspectionDal.Add(inspection);
        }

        public bool CheckTheLocation(string parallel, string meridian, int employeeId)
        {
            var result = true;
            var emp = _employeeService.GetById(employeeId);
            var dept = _departmentService.GetById(emp.DepartmentID);
            var double_parallel = Convert.ToDouble(parallel);
            var double_meridian = Convert.ToDouble(meridian);
            var target_parallelTop = Convert.ToDouble(dept.ParallelTop);
            var target_parallelBottom = Convert.ToDouble(dept.ParallelBottom);
            var target_meridianLeft = Convert.ToDouble(dept.MeridianLeft);
            var target_meridianRight = Convert.ToDouble(dept.MeridianRight);


            if (target_meridianLeft <= double_meridian && double_meridian <= target_meridianRight &&
                target_parallelTop >= double_parallel && double_parallel >= target_parallelBottom) {
                _inspectionDal.Add(new Inspection
                {
                    EmployeeID = employeeId,
                    Parallel = parallel,
                    Meridian = meridian,
                    CheckIsInLocation = "true",
                    CheckTime = DateTime.Now
                });
            }
            else
            {
                _inspectionDal.Add(new Inspection
                {
                    EmployeeID = employeeId,
                    Parallel = parallel,
                    Meridian = meridian,
                    CheckIsInLocation = "false",
                    CheckTime = DateTime.Now
                });
                result = false;
            }
            return result;
        }

        public void Delete(Inspection inspection)
        {
            _inspectionDal.Delete(inspection);
        }

        public List<Inspection> GetAll()
        {
            return _inspectionDal.GetAll();

        }

        public Inspection GetById(int inspectionId)
        {
            var result = _inspectionDal.Get(i => i.InspectionID == inspectionId);
            return result;
        }

        public List<InspectionDetailDto> GetInspectionDetails()
        {
            var result = _inspectionDal.GetInspectionDetails();
            return result;
        }

        public void Update(Inspection inspection)
        {
            _inspectionDal.Update(inspection);
        }
    }
}
