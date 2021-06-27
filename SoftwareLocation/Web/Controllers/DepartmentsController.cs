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
        IAuthorityService _authorityService;

        public DepartmentsController(IDepartmentService departmentService, IAuthorityService authorityService)
        {
            _departmentService = departmentService;
            _authorityService = authorityService;
        }

        [HttpGet("getall")]
        public List<Department> GetAll(string token)
        {
            if (_authorityService.GetByToken(token)!=null)
            {
                var result = _departmentService.GetAll();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getbyid")]
        public Department GetById(int id, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _departmentService.GetById(id);
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("add")]
        public string Add(Department department , string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                 _departmentService.Add(department);
                return "Department Added Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpPost("update")]
        public string Update(Department department , string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                _departmentService.Update(department);
                return "Department Updated Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpDelete("delete")]
        public string Delete(Department department , string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                _departmentService.Delete(department);
                return "Department Deleted Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

    }
}
