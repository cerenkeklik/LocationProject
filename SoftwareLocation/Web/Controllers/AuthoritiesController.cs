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
    public class AuthoritiesController : ControllerBase
    {
        IAuthorityService _authorityService;

        public AuthoritiesController(IAuthorityService authorityService)
        {
            _authorityService = authorityService;

        }

        [HttpGet("getbytoken")]
        public Authority GetById(string token)
        {
            var result = _authorityService.GetByToken(token);
            return result;
        }

        [HttpPost("add")]
        public string Add(Authority authority, string token)
        {
            if (_authorityService.GetByToken(token)!=null)
            {
                _authorityService.Add(authority);
                return "Authority added successfully";
            }
            else
            {
                return "Access denied!";
            }
            
        
        
        }





    }
}
