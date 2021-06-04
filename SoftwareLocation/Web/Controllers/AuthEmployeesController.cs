﻿using Core.DTOs;
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

        public AuthEmployeesController(IAuthService<Employee, EmployeeRegisterDto> authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public AccessToken Login(LoginDto loginDto)
        {
            var userToLogin = _authService.Login(loginDto);
            if (userToLogin == null)
            {
                return null;
            }

            var result = _authService.CreateAccessToken(userToLogin);
            if (result !=null)
            {
                return result;
            }

            return null;
        }

        [HttpPost("register")]
        public AccessToken Register(EmployeeRegisterDto registerDto)
        {
            var userExists = _authService.UserExists(registerDto.Email);
            if (!userExists)
            {
                return null;
            }

            var registerResult = _authService.Register(registerDto, registerDto.Password);
            var result = _authService.CreateAccessToken(registerResult);
            if (result != null)
            {
                return result;
            }

            return null;
        }
    }
}