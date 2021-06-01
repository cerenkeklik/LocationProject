using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getall")]
        public List<Department> GetAll()
        {
          var result = _departmentService.GetAll();
            return result;
        }

        [HttpGet("getbyid")]
        public Department GetById(int id)
        {
            var result = _departmentService.GetById(id);
            return result;
        }

        [HttpPost("add")]
        public void Add(Department department) {
            _departmentService.Add(department);
        }

        [HttpPost("update")]
        public void Update(Department department) {
            _departmentService.Update(department);
        }

        [HttpPost("delete")]
        public void Delete(Department department) {
            _departmentService.Delete(department);
        }

    }
}
