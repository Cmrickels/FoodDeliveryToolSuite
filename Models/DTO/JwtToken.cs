using System;
using System.IdentityModel.Tokens.Jwt;

namespace ApiGateway.Models.Dto
{
    public class JwtToken 
    {
        public string token;
        public DateTime expiration; 

        public JwtToken(JwtSecurityToken token) 
        {
            this.token = new JwtSecurityTokenHandler().WriteToken(token);
            this.expiration = token.ValidTo;
        }
    }
}