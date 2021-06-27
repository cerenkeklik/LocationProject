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
    public class ExcusesController : ControllerBase
    {
        IExcuseService _excuseService;
        IAuthorityService _authorityService;

        public ExcusesController(IExcuseService excuseService, IAuthorityService authorityService)
        {
            _excuseService = excuseService;
            _authorityService = authorityService;
        }

        [HttpGet("getall")]
        public List<Excuse> GetAll(string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _excuseService.GetAll();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getbyid")]
        public Excuse GetById(int id,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _excuseService.GetById(id);
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("add")]
        public string Add(Excuse excuse,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _excuseService.Add(excuse);
                return "Excuse Added Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpPost("update")]
        public string Update(Excuse excuse,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _excuseService.Update(excuse);
                return "Excuse Updated Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpDelete("delete")]
        public string Delete(Excuse excuse ,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _excuseService.Delete(excuse);
                return "Excuse Deleted Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpGet("getdetails")]
        public List<ExcuseDetailDto> GetDetails(string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _excuseService.GetExcuseDetails();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getdetailsbyid")]
        public ExcuseDetailDto GetDetailsById(int id , string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _excuseService.GetExcuseDetailsById(id);
                return result;
            }
            else
            {
                return null;
            }
        }

    }

}

