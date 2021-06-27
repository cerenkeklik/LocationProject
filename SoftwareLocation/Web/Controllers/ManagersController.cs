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
    public class ManagersController : ControllerBase
    {
        IManagerService _managerService;
        IAuthorityService _authorityService;

        public ManagersController(IManagerService managerService,IAuthorityService authorityService)
        {
            _managerService = managerService;
            _authorityService = authorityService;

        }

        [HttpGet("getall")]
        public List<Manager> GetAll(string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _managerService.GetAll();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getbyid")]
        public Manager GetById(int id, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _managerService.GetById(id);
                return result;
            }
            else
            {
                return null;
            }
        }

        

        [HttpPost("update")]
        public string Update(Manager manager, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _managerService.Update(manager);
                return "Manager Updated Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpDelete("delete")]
        public string Delete(Manager manager, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _managerService.Delete(manager);
                return "Manager Deleted Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }
    }
}
