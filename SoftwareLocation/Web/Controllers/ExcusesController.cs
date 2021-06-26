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

        public ExcusesController(IExcuseService excuseService)
        {
            _excuseService = excuseService;
        }

        [HttpGet("getall")]
        public List<Excuse> GetAll()
        {
            var result = _excuseService.GetAll();
            return result;
        }

        [HttpGet("getbyid")]
        public Excuse GetById(int id)
        {
            var result = _excuseService.GetById(id);
            return result;
        }

        [HttpPost("add")]
        public void Add(Excuse excuse)
        {
            _excuseService.Add(excuse);
        }

        [HttpPost("update")]
        public void Update(Excuse excuse)
        {
            _excuseService.Update(excuse);
        }

        [HttpDelete("delete")]
        public void Delete(Excuse excuse)
        {
            _excuseService.Delete(excuse);
        }

        [HttpGet("getdetails")]
        public List<ExcuseDetailDto> GetDetails()
        {
            var result = _excuseService.GetExcuseDetails();
            return result;
        }

        [HttpGet("getdetailsbyid")]
        public ExcuseDetailDto GetDetailsById(int id)
        {
            var result = _excuseService.GetExcuseDetailsById(id);
            return result;
        }

    }

}

