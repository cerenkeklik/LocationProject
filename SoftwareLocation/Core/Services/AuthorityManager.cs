using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class AuthorityManager : IAuthorityService
    {
        IAuthorityDal _authorityDal;

        public AuthorityManager(IAuthorityDal authorityDal)
        {
            _authorityDal = authorityDal;
        }


        public void Add(Authority authority)
        {
            _authorityDal.Add(authority);

        }

        public Authority GetByToken(string token)
        {
            return _authorityDal.Get(a => a.Token == token);
        }
    }
}
