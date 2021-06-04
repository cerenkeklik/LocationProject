using Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedKernel;
using SharedKernel.Security;
using SharedKernel.Security.JWT;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Infrastructure.Security.JWT
{
    public class JwtHelper<TEntity> : ITokenHelper<TEntity> where TEntity: class, IEntity
    {
        //IConfiguration appsettingsdeki değerleri okumaya yarar
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions; //appsettingsdeki değerler
        private DateTime _accessTokenExpiration; //accesstoken süresi
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //appsettingdeki token options bölümünü al ve maple
        }
        public AccessToken CreateToken(TEntity user)
        {//kullanıcı için token üretiyoruz. User ve claime göre token oluşturur

            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, TEntity user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
            );
            return jwt;
        }
    }
}
