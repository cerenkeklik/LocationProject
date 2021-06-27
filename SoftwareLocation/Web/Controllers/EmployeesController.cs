using Core.DTOs;
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
        IAuthorityService _authorityService;

        public EmployeesController(IEmployeeService employeeService , IAuthorityService authorityService)
        {
            _employeeService = employeeService;
            _authorityService = authorityService;
        }

        [HttpGet("getall")]
        public List<Employee> GetAll(string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _employeeService.GetAll();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getbyid")]
        public Employee GetById(int id,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _employeeService.GetById(id);
                return result;
            }
            else
            {
                return null;
            }
        }

       

        [HttpPost("update")]
        public string Update(Employee employee, string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                _employeeService.Add(employee);
                return "Employee Updated Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpDelete("delete")]
        public string Delete(Employee employee, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _employeeService.Delete(employee);
                return "Employee Deleted Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpGet("getdetails")]
        public List<EmployeeDetailDto> GetDetails(string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                var result= _employeeService.GetEmployeeDetails();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getdetailsbyid")]
        public EmployeeDetailDto GetDetailsById(int id,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _employeeService.GetEmployeeDetailsById(id);
                return result;

            }
            else
            {
                return null;
            }
        }

        [HttpGet("getbymail")]
        public Employee GetByMail(string mail,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _employeeService.GetByMail(mail);
                return result;

            }
            else
            {
                return null;
            }
        }
    }
}
