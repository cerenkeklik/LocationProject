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

        public ManagersController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet("getall")]
        public List<Manager> GetAll() {
            var result = _managerService.GetAll();
            return result;
        }

        [HttpGet("getbyid")]
        public Manager GetById(int id)
        {
            var result = _managerService.GetById(id);
            return result;
        }

        [HttpPost("add")]
        public void Add(Manager manager) {
            _managerService.Add(manager);
        }

        [HttpPost("update")]
        public void Update(Manager manager)
        {
            _managerService.Update(manager);
        }

        [HttpDelete("delete")]
        public void Delete(Manager manager)
        {
            _managerService.Delete(manager);
        }
    }
}
