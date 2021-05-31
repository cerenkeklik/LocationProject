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
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public List<Employee> GetAll()
        {
            var result = _employeeService.GetAll();
            return result;
        }

        [HttpGet("getbyid")]
        public Employee GetById(int id)
        {
            var result = _employeeService.GetById(id);
            return result;
        }
    }
}
