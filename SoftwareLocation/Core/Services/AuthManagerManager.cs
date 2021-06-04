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
    public class AuthManagerManager : IAuthService<Manager, ManagerRegisterDto>
    {
        private IManagerService _managerService;
        private ITokenHelper<Manager> _tokenHelper;

        public AuthManagerManager(IManagerService managerService, ITokenHelper<Manager> tokenHelper)
        {
            _managerService = managerService;
            _tokenHelper = tokenHelper;
        }

        public Manager Register(ManagerRegisterDto registerDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var manager = new Manager

            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                Phone = registerDto.Phone
               


            };
            _managerService.Add(manager);
            return manager;
        }

        public Manager Login(LoginDto loginDto)
        {
            var userToCheck = _managerService.GetByMail(loginDto.Email);
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
            if (_managerService.GetByMail(email) != null)
            {
                return false;
            }
            return true;
        }

        public AccessToken CreateAccessToken(Manager manager)
        {
            var accessToken = _tokenHelper.CreateToken(manager);
            return accessToken;
        }
    }
}
