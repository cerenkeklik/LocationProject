using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using SharedKernel.Security;
using SharedKernel.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class AuthEmployeeManager : IAuthService<Employee, EmployeeRegisterDto> 
    {
        private IEmployeeService _employeeService;
        private ITokenHelper<Employee> _tokenHelper;

        public AuthEmployeeManager(IEmployeeService employeeService, ITokenHelper<Employee> tokenHelper)
        {
            _employeeService = employeeService;
            _tokenHelper = tokenHelper;
        }

        public Employee Register(EmployeeRegisterDto registerDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var employee = new Employee
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Address = registerDto.Address,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                DepartmentID=registerDto.DepartmentID,
                Phone=registerDto.Phone

               
            };
            _employeeService.Add(employee);
            return employee;
        }

        public Employee Login(LoginDto loginDto)
        {
            var userToCheck = _employeeService.GetByMail(loginDto.Email);
            if (userToCheck == null)
            {
                return null;
            }

            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return null;
            }

            return userToCheck;
        }

        public bool UserExists(string email)
        {
            if (_employeeService.GetByMail(email) != null)
            {
                return false;
            }
            return true;
        }

        public AccessToken CreateAccessToken(Employee employee)
        {
            var accessToken = _tokenHelper.CreateToken(employee);
            return accessToken;
        }
    }
}
