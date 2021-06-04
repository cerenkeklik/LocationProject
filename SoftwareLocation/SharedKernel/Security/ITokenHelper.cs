
using SharedKernel;
using SharedKernel.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Security.JWT
{
    public interface ITokenHelper<T> where T : class, IEntity
    {
        AccessToken CreateToken(T user);
       
    }
}
