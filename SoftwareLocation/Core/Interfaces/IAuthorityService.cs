using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAuthorityService
    {
        void Add(Authority authority);

     

         Authority GetByToken(string token);


       


    }
}
