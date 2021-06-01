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

        public InspectionsController(IInspectionService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        [HttpGet("getall")]
        public List<Inspection> GetAll() {
            var result = _inspectionService.GetAll();
            return result;
        }

        [HttpGet("getbyid")]
        public Inspection GetById(int id)
        {
            var result = _inspectionService.GetById(id);
            return result;
        }

        [HttpGet("getdetails")]
        public List<InspectionDetailDto> GetDetails() {
            var result = _inspectionService.GetInspectionDetails();
            return result;
        }

        [HttpPost("add")]
        public void Add(Inspection inspection)
        {
            _inspectionService.Add(inspection);
        }

        [HttpPost("update")]
        public void Update(Inspection inspection) {
            _inspectionService.Update(inspection);
        }

        [HttpPost("delete")]
        public void Delete(Inspection inspection) {
            _inspectionService.Delete(inspection);        
        }
    }
}
