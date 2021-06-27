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
    public class InspectionsController : ControllerBase
    {
        IInspectionService _inspectionService;
        IAuthorityService _authorityService;

        public InspectionsController(IInspectionService inspectionService,IAuthorityService authorityService)
        {
            _inspectionService = inspectionService;
            _authorityService = authorityService;
        }

        [HttpGet("getall")]
        public List<Inspection> GetAll(string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _inspectionService.GetAll();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getbyid")]
        public Inspection GetById(int id, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _inspectionService.GetById(id);
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("getdetails")]
        public List<InspectionDetailDto> GetDetails(string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                var result = _inspectionService.GetInspectionDetails();
                return result;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("add")]
        public string Add(Inspection inspection, string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                _inspectionService.Add(inspection);
                return "Inspection Added Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpPost("update")]
        public string Update(Inspection inspection, string token) {
             if (_authorityService.GetByToken(token) != null)
            {
                _inspectionService.Add(inspection);
                return "Inspection Added Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpDelete("delete")]
        public string Delete(Inspection inspection, string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                _inspectionService.Delete(inspection);
                return "Inspection Deleted Successfully";
            }
            else
            {
                return "Access Denied";
            }
        }

        [HttpPost("checklocation")]
        public bool CheckLocation(string parallel, string meridian, int employeeId, string token) {
            if (_authorityService.GetByToken(token) != null)
            {
                return _inspectionService.CheckTheLocation(parallel, meridian, employeeId);
            }
            else
            {
                return false;
            }
        }


    }
}
