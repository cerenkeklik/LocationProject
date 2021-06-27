using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthEmployeesController : ControllerBase
    {
        private IAuthService<Employee, EmployeeRegisterDto> _authService;
        private IAuthorityService _authorityService;

        public AuthEmployeesController(IAuthService<Employee, EmployeeRegisterDto> authService,IAuthorityService authorityService)
        {
            _authService = authService;
            _authorityService = authorityService;
        }

        [HttpPost("login")]
        public int Login(LoginDto loginDto,string token)
        {
            if (_authorityService.GetByToken(token) != null)
            {
                var userToLogin = _authService.Login(loginDto);
                if (userToLogin == null)
                {
                    return -1;
                }
                else
                {
                    return userToLogin.EmployeeID;
                }
            }
            else
            {
                return 401;
            }

            

           
        }

        [HttpPost("register")]
        public bool Register(EmployeeRegisterDto registerDto, string token)
        {
            if (_authorityService.GetByToken(token)!=null)
            {


                var userExists = _authService.UserExists(registerDto.Email);
                if (!userExists)
                {
                    return false;
                }

                var registerResult = _authService.Register(registerDto, registerDto.Password);
                return true;

            }
            return false;
        
           
        }
    }
}
