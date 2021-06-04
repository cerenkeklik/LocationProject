using Core.DTOs;
using SharedKernel.Security.JWT;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAuthService<T,TDto> 
        where T: class, IEntity
        where TDto: class, IDto
    {
        T Register(TDto registerDto, string password);
        T Login(LoginDto loginDto);
        bool UserExists(string email);
        AccessToken CreateAccessToken(T user);
    }
}
