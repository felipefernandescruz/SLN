using Authentication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Authentication.Security
{
    public  class Token
    {
        private readonly TokenConfiguration configuracaoToken;

        private readonly SigningConfigurations signingConfigurations;

        public Token(TokenConfiguration pConfiguracaoToken, SigningConfigurations pSigningConfigurations)
       
        {
            configuracaoToken = pConfiguracaoToken;
            signingConfigurations = pSigningConfigurations;
        }


        public BodyToken GeraToken(User usuario, TokenConfiguration pTokenConfigurations)
        {
            //SigningConfigurations signingConfigurations = new SigningConfigurations();

            BodyToken token = new BodyToken();
            try
            {
                

                ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(usuario.firstName, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.firstName)
                   }
               );

                //TODO: Alterar para que valores venham do appsetinhs.json
                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromHours(configuracaoToken.Hours);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = configuracaoToken.Issuer,
                    Audience = configuracaoToken.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                token.token = handler.WriteToken(securityToken);
                token.dtStartToken = DateTime.Now;
                token.dtExpirationToken = DateTime.Now.AddHours(pTokenConfigurations.Hours);


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return token;

        }
    }
}
